using DeliveryManager.Domain.Deliveries;
using DeliveryManager.Domain.Deliveries.Repositories;
using DeliveryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManager.Infrastructure.Repositories;

public class DeliveryRepository(DeliveryManagerDbContext context) : IDeliveryRepository
{
    public async Task<Delivery> CreateAsync(Delivery delivery, CancellationToken cancellationToken)
    {
        await context.Deliveries.AddAsync(delivery, cancellationToken);
        return delivery;
    }

    public async Task<IEnumerable<Delivery>> GetListAsync(CancellationToken cancellationToken)
        => await context.Deliveries.ToListAsync(cancellationToken); 

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await context.SaveChangesAsync(cancellationToken);
}