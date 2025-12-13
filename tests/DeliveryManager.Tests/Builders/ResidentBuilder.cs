using DeliveryManager.Domain.Resident;
using DeliveryManager.Domain.Delivery.ValueObjects;

namespace DeliveryManager.Tests.Builders;

public class ResidentBuilder
{
    private string? _name = "Renan";
    private string? _surname = "Salustiano";
    private Address? _address = Address.Create("Rua 1", 1, "São Paulo", "SP", "00000000");

    public static ResidentBuilder Valid()
    {
        return new ResidentBuilder();
    }

    public ResidentBuilder WithName(string name)
    {
         _name = name;
         return this;
    }
    
    public ResidentBuilder WithOutName()
    {
        _name = null;
        return this;
    }

    public ResidentBuilder WithSurname(string surname)
    {
        _surname = surname;
        return this;
    }
    
    public ResidentBuilder WithOutSurname()
    {
        _surname = null;
        return this;
    }

    public ResidentBuilder WithAddress(Address address)
    {
        _address = address;
        return this;
    }
    
    public ResidentBuilder WithOutAddress()
    {
        _address = null;
        return this;
    }

    public Resident Build()
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return Resident.Create(_name, _surname, _address);
#pragma warning restore CS8604 // Possible null reference argument.
    }
}