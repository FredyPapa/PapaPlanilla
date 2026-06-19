using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Papa.Planilla.Domain.Ports.Messages;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Infraestructure.Adapters.Messages;
using Papa.Planilla.Infraestructure.Adapters.Repositories;
using Papa.Planilla.Infraestructure.Adapters.Services;
using Papa.Planilla.Infraestructure.Configuration.Messages;
using Papa.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Inyección de dependencia del Contexto
            services.AddDbContext<PlanillaDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbPlanilla")));

            //Inyección de dependencia de Repositorios
            services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IUnidadOrganicaRepository, UnidadOrganicaRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IPlanillaRepository, PlanillaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DomainEventDispatcher>();

            // Configuración de RabbitMQ
            var rabbitSettings = configuration.GetSection("RabbitSetting").Get<RabbitSettings>()
                ?? throw new InvalidOperationException("RabbitSetting configuration section is missing.");
            services.AddSingleton(rabbitSettings);
            services.AddSingleton<RabbitConfiguration>();
            services.AddScoped<IRabbitProducerService, RabbitProducerService>();
            services.AddScoped<IRabbitConsumerService, RabbitConsumerService>();

            return services;
        }
    }
}
