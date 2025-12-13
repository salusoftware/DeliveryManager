namespace DeliveryManager.Domain.Deliveries.Repositories;

public interface IDeliveryRepository
{
        Task<Delivery> CreateAsync(Delivery delivery, CancellationToken cancellationToken);
        Task<IEnumerable<Delivery>> GetListAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
}