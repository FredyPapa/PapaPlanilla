using Microsoft.Extensions.DependencyInjection;
using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Features.Cargo.UseCases;
using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Features.Contrato.UseCases;
using Papa.Planilla.Application.Features.Planilla.Ports;
using Papa.Planilla.Application.Features.Planilla.UseCases;
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
            services.AddScoped<IGetTrabajadorByIdUseCase, GetTrabajadorByIdUseCase>();
            services.AddScoped<IUpdateTrabajadorUseCase, UpdateTrabajadorUseCase>();
            services.AddScoped<IDeleteTrabajadorUseCase, DeleteTrabajadorUseCase>();
            services.AddScoped<TrabajadorUseCases>();
            services.AddScoped<ICreateCargoUseCase, CreateCargoUseCase>();
            services.AddScoped<IListCargoUseCase, ListCargoUseCase>();
            services.AddScoped<IGetCargoByIdUseCase, GetCargoByIdUseCase>();
            services.AddScoped<IUpdateCargoUseCase, UpdateCargoUseCase>();
            services.AddScoped<IDeleteCargoUseCase, DeleteCargoUseCase>();
            services.AddScoped<CargoUseCases>();
            services.AddScoped<ICreateUnidadOrganicaUseCase, CreateUnidadOrganicaUseCase>();
            services.AddScoped<IListUnidadOrganicaUseCase, ListUnidadOrganicaUseCase>();
            services.AddScoped<IGetUnidadOrganicaByIdUseCase, GetUnidadOrganicaByIdUseCase>();
            services.AddScoped<IUpdateUnidadOrganicaUseCase, UpdateUnidadOrganicaUseCase>();
            services.AddScoped<IDeleteUnidadOrganicaUseCase, DeleteUnidadOrganicaUseCase>();
            services.AddScoped<UnidadOrganicaUseCases>();
            services.AddScoped<ICreateContratoUseCase, CreateContratoUseCase>();
            services.AddScoped<IListContratoUseCase, ListContratoUseCase>();
            services.AddScoped<IGetContratoByIdUseCase, GetContratoByIdUseCase>();
            services.AddScoped<IUpdateContratoUseCase, UpdateContratoUseCase>();
            services.AddScoped<IDeleteContratoUseCase, DeleteContratoUseCase>();
            services.AddScoped<ContratoUseCases>();
            services.AddScoped<ICreatePlanillaUseCase, CreatePlanillaUseCase>();
            services.AddScoped<IListPlanillaUseCase, ListPlanillaUseCase>();
            services.AddScoped<IGetPlanillaByIdUseCase, GetPlanillaByIdUseCase>();
            services.AddScoped<IUpdatePlanillaUseCase, UpdatePlanillaUseCase>();
            services.AddScoped<IDeletePlanillaUseCase, DeletePlanillaUseCase>();
            services.AddScoped<PlanillaUseCases>();
            //
            return services;
        }
    }
}
