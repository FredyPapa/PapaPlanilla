using Microsoft.EntityFrameworkCore;
using Npgsql;
using Papa.Planilla.Application.Results;
using System.Text.Json;

namespace Papa.Planilla.API.Middelwares
{
    public class ExceptionHandlingMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddelware> _logger;

        public ExceptionHandlingMiddelware(RequestDelegate next, ILogger<ExceptionHandlingMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción no controlada al procesar la petición: {0}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = StatusCodes.Status400BadRequest;
            
            //Mensaje de respuesta personalizado para errores específicos, como violaciones de restricciones de la base de datos (en español)
            string mensajePersonalizado = "Ocurrió un error inesperado en el sistema.";
            if (exception is DbUpdateException dbEx)
            {
                // Revisamos si la causa interna es una violación de restricciones de PostgreSQL (como llaves duplicadas)
                if (dbEx.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
                {
                    mensajePersonalizado = "No se pudo registrar: Ya existe un registro con el mismo identificador o documento de identidad.";
                }
                else
                {
                    mensajePersonalizado = "Ocurrió un problema al persistir los datos en la base de datos de planillas.";
                }
            }
            else if (exception is ArgumentException || exception is ArgumentNullException)
            {
                mensajePersonalizado = exception.Message; // Se mantiene los mensajes colocados en las Entidades y otros
            }
            else
            {
                // Para cualquier otro error genérico no controlado
                mensajePersonalizado = exception.Message;
            }
            //
            //var result = Result.Failure(exception.Message,statusCode);
            var result = Result.Failure(mensajePersonalizado, statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var payload = JsonSerializer.Serialize(result, options);

            await context.Response.WriteAsync(payload);
        }
    }
}
