using Papa.Planilla.Application;
using Papa.Planilla.Infraestructure;
using Papa.PlanillaWorker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddApplication()
    .AddInfraestructure(builder.Configuration);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
await host.RunAsync();
