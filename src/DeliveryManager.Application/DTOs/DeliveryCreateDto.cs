namespace DeliveryManager.Application.DTOs;

public record DeliveryCreateDto(string Name, string? Carrier, string? KeyWork, string? TrackingCode);