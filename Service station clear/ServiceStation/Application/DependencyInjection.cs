using System.Reflection;
using Application.Interfaces;
using Application.Operations.Models.Commands;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IMechanicService, MechanicService>();
            services.AddScoped<IMechanicsTasksService, MechanicsTasksService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IOrderPartsService, OrderPartsService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPartNeededService, PartNeededService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IUnitOfServices, UnitOfServices>();
            services.AddScoped<IVendorsService, VendorsService>();


            return services;
        }



    }
}
