namespace DeliveryManager.Application.Deliveries.ReadModels;

public sealed record DeliveryReadModel(Guid Id, string? Name, string? Carrier, string? KeyWord, string? TrackingCode);