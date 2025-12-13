using DeliveryManager.Domain.Delivery;
using DeliveryManager.Domain.Delivery.Repositories;
using DeliveryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManager.Infrastructure.Repositories;

public class DeliveryRepository(DeliveryManagerDbContext context) : IDeliveryRepository
{
    public async Task<Delivery> CreateAsync(Delivery delivery)
    {
        await context.Deliveries.AddAsync(delivery);
        return delivery;
    }

    public async Task<IEnumerable<Delivery>> GetListAsync()
        => await context.Deliveries.ToListAsync(); 

    public async Task CommitAsync()
        => await context.SaveChangesAsync();
}