namespace DeliveryManager.Application.DTOs;

public record DeliveryCreateDto(string Name, string? Carrier, string? KeyWord, string? TrackingCode);