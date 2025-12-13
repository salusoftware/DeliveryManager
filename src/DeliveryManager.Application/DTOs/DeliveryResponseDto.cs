namespace DeliveryManager.Application.DTOs;

public record DeliveryResponseDto(Guid Id, string? Name, string? Carrier, string? KeyWord, string? TrackingCode);