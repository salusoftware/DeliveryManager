namespace DeliveryManager.Application.DTOs;

public record ResidentCreateDto(string Name, string Surname,  AddressCreateDto Address);