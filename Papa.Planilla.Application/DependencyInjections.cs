using Microsoft.Extensions.DependencyInjection;
using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Features.Cargo.UseCases;
using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Features.Contrato.UseCases;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Features.Trabajador.UseCases;
using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using Papa.Planilla.Application.Features.UnidadOrganica.UseCases;
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
            services.AddScoped<ICreateCargoUseCase, CreateCargoUseCase>();
            services.AddScoped<IListCargoUseCase, ListCargoUseCase>();
            services.AddScoped<CargoUseCases>();
            services.AddScoped<ICreateUnidadOrganicaUseCase, CreateUnidadOrganicaUseCase>();
            services.AddScoped<IListUnidadOrganicaUseCase, ListUnidadOrganicaUseCase>();
            services.AddScoped<UnidadOrganicaUseCases>();
            services.AddScoped<ICreateContratoUseCase, CreateContratoUseCase>();
            services.AddScoped<IListContratoUseCase, ListContratoUseCase>();
            services.AddScoped<ContratoUseCases>();
            //
            return services;
        }
    }
}
