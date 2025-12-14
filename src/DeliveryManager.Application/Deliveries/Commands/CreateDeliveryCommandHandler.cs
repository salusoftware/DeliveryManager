using DeliveryManager.Application.Common;
using DeliveryManager.Application.Deliveries.ReadModels;
using DeliveryManager.Domain.Deliveries;
using DeliveryManager.Domain.Deliveries.Repositories;

namespace DeliveryManager.Application.Deliveries.Commands;

public sealed class CreateDeliveryCommandHandler(IDeliveryRepository repo) : IHandler
{
    public async Task<DeliveryReadModel> Handle(CreateDeliveryCommand request, CancellationToken ct)
    {
        var delivery = Delivery.Create(
            request.Name, 
            request.ResidentId, 
            request.Carrier, 
            request.KeyWork, 
            request.TrackingCode);

        await repo.CreateAsync(delivery, ct);
        await repo.CommitAsync(ct);

        return new DeliveryReadModel(
            delivery.Id,
            delivery.Name,
            delivery.Carrier,
            delivery.KeyWord,
            delivery.TrackingCode);
    }
}