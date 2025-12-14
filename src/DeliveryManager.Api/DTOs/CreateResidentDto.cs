namespace DeliveryManager.Api.DTOs;

public record CreateResidentDto(string Name, string Surname, CreateAddressDto Address );