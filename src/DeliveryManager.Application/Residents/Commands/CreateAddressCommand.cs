namespace DeliveryManager.Application.Residents.Commands;

public sealed record CreateAddressCommand(string  Street, string  City, string  State, int Number, string ZipCode);