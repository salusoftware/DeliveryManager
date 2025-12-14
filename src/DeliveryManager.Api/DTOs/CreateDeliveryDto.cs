namespace DeliveryManager.Api.DTOs;

public record CreateDeliveryDto(string Name, Guid ResidentId, string? Carrier, string? KeyWord, string? TrackingCode);