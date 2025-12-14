using DeliveryManager.Application.Deliveries.ReadModels;
using MediatR;

namespace DeliveryManager.Application.Deliveries.Commands;

public record CreateDeliveryCommand(
    string Name,
    Guid ResidentId,
    string? Carrier,
    string? KeyWord,
    string? TrackingCode
) : IRequest<DeliveryReadModel>;