using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Infraestructure.Adapters.Repositories;
using Papa.Planilla.Infraestructure.Adapters.Services;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
