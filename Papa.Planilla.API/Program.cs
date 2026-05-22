using Papa.Planilla.Infraestructure;
using Papa.Planilla.Application;
using Microsoft.AspNetCore.Diagnostics;
using Papa.Planilla.API.Middelwares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Inyección de dependencia (y Conexión a la base de datos)
builder.Services
    .AddApplication()
    .AddInfraestructure(builder.Configuration);

var app = builder.Build();

//Middelwares
app.UseMiddleware<ExceptionHandlingMiddelware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
