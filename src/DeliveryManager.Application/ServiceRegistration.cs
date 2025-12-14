using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DeliveryManager.Application.Common;

namespace DeliveryManager.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // AutoMapper
        //services.AddAutoMapper(assembly);

        // Validators
        services.AddValidatorsFromAssembly(assembly);

        // Use cases (assembly scanning)
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IHandler)))
            .AsSelf()
            .WithScopedLifetime());

        return services;
    }
}