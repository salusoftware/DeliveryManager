namespace DeliveryManager.Domain.Delivery.Repositories;

public interface IDeliveryRepository
{
        Task<Delivery> CreateAsync(Delivery delivery);
        Task<IEnumerable<Delivery>> GetListAsync();
}