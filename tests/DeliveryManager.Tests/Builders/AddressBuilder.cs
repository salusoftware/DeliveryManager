using DeliveryManager.Domain.Residents.ValueObjects;

namespace DeliveryManager.Tests.Builders;

public class AddressBuilder
{
    private int _number = 1;
    private string? _street = "Rua 1";
    private string? _zipCode = new string('0', 8);
    private string? _city = "São Paulo";
    private string? _state = "SP";

    public AddressBuilder WithNumber(int number)
    {
        _number = number;
        return this;
    }
    
    public AddressBuilder WithInvalidNumber()
    {
        _number = -1;
        return this;
    }
    
    public AddressBuilder WithStreet(string street)
    {
        _street = street;
        return this;
    }

    public AddressBuilder WithOutStreet()
    {
        _street = null;
        return this;
    }

    
    public AddressBuilder WithZipCode(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }
    
    public AddressBuilder WithOutZipCode()
    {
        _zipCode = null;
        return this;
    }
    
    public AddressBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }
    
    public AddressBuilder WithOutCity()
    {
        _city = null;
        return this;
    }
    
    public AddressBuilder WithState(string state)
    {
        _state = state;
        return this;
    }
    
    public AddressBuilder WithOutState()
    {
        _state = null;
        return this;
    }

    

    public static AddressBuilder Valid()
    {
        return new AddressBuilder();
    }
    
    public Address Build()
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return Address.Create(_street, _number, _city, _state, _zipCode); 
#pragma warning restore CS8604 // Possible null reference argument.
    }
}