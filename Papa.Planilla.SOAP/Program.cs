using Papa.Planilla.Application;
using Papa.Planilla.Infraestructure;
using Papa.Planilla.SOAP.Endpoints.Trabajador;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddApplication()
    .AddInfraestructure(builder.Configuration);

builder.Services.AddSoapCore();

builder.Services.AddScoped<ITrabajadorService,TrabajadorService>();
//

var app = builder.Build();

//
app.UseHttpsRedirection();
app.UseRouting()
    .UseSoapEndpoint<ITrabajadorService>("/TrabajadorService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
//

app.Run();
