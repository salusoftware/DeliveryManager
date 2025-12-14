namespace DeliveryManager.Application.Residents.Commands;

public sealed record CreateResidentCommand(string Name, string Surname, CreateAddressCommand Address);