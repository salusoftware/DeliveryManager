using System.Text.RegularExpressions;
using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Domain.Shared.Validation;

namespace DeliveryManager.Domain.Residents.ValueObjects;

public sealed class Address : IEquatable<Address>
{
    public string Street { get; }
    public int Number { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }
    
    private static readonly Regex CepRegex = new(@"^\d{5}-?\d{3}$", RegexOptions.Compiled);
    private static readonly Regex StateRegex = new(@"^[A-Z]{2}$", RegexOptions.Compiled);
    private Address(string street, int number, string city, string state, string zipCode)
    {
        Street = street;
        Number = number;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
    
    public static Address Create(string street, int number, string city, string state, string zipCode)
    {
        if (number <= 0)
            throw new DomainException(AddressErrors.InvalidNumber);
        

        //Street
        Guard.Required(street, AddressErrors.StreetRequired);
        Guard.MaxLength(street, AddressErrors.StreetMaxLength);

        //City
        Guard.Required(city, AddressErrors.CityRequired);
        Guard.MaxLength(city, AddressErrors.CityMaxLength);

        //State
        Guard.Required(state, AddressErrors.StateRequired);
        if (!StateRegex.IsMatch(state))
            throw new DomainException(AddressErrors.InvalidState);

        //ZipCode
        zipCode = NormalizeZipCode(zipCode);
        ValidateZipCode(zipCode);
        
        
        return new Address(street, number, city, state, zipCode);
    }
    
    
    private static string NormalizeZipCode(string zipCode)
    {
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new DomainException(AddressErrors.ZipCodeRequired);

        return zipCode.Replace("-", "");
    }
    
    private static void ValidateZipCode(string zipCode)
    {
        if (!CepRegex.IsMatch(zipCode))
            throw new DomainException(AddressErrors.ZipCodeInvalidFormat);
    }
    
    
        
    // Comparação por valor
    public override bool Equals(object? obj)
        => obj is Address other && Equals(other);
    public bool Equals(Address? other)
    {
        if (other is null) return false;

        return Street == other.Street &&
               Number == other.Number &&
               City == other.City &&
               State == other.State &&
               ZipCode == other.ZipCode;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Street, Number, City, State, ZipCode);
    }

}