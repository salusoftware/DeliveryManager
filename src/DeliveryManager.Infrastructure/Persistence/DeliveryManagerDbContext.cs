using DeliveryManager.Domain.Deliveries;
using DeliveryManager.Domain.Residents;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManager.Infrastructure.Persistence;

public class DeliveryManagerDbContext : DbContext
{
    public DeliveryManagerDbContext(DbContextOptions<DeliveryManagerDbContext> options) : base(options) {}
    
    public DbSet<Delivery>  Deliveries { get; set; }
    public DbSet<Resident>  Residents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryManagerDbContext).Assembly);
    }
}