namespace DeliveryManager.Application.DTOs;

public abstract record AddressCreateDto(string Street, string City, string State, string ZipCode, int Number);