using DeliveryManager.Domain.Deliveries.Repositories;
using DeliveryManager.Domain.Residents.Repositories;
using DeliveryManager.Infrastructure.Persistence;
using DeliveryManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryManager.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        Console.WriteLine("connection String: " + connectionString);

        services.AddDbContext<DeliveryManagerDbContext>(options =>
            options.UseNpgsql(
                connectionString,
                x => x.MigrationsAssembly("DeliveryManager.Infrastructure")));

        // Repositories
        services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        services.AddScoped<IResidentRepository, ResidentRepository>();

        return services;
    }
}