namespace DeliveryManager.Api.DTOs;

public record CreateAddressDto(string Street, string City, string State, string ZipCode, int Number);