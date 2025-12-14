namespace DeliveryManager.Application.Residents.ReadModels;

public record ResidentReadModel(Guid Id, string Name, string Surname,  string Street, string City, string State, int Number, string ZipCode);