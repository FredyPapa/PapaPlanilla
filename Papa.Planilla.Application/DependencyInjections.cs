using Microsoft.Extensions.DependencyInjection;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Features.Trabajador.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateTrabajadorUseCase, CreateTrabajadorUseCase>();
            services.AddScoped<IListTrabajadorUseCase, ListTrabajadorUseCase>();
            services.AddScoped<TrabajadorUseCases>();
            //
            return services;
        }
    }
}
