namespace DeliveryManager.Application.Deliveries.Commands;

public abstract record CreateDeliveryCommand(string Name, Guid ResidentId,  string? Carrier, string? KeyWork, string? TrackingCode);