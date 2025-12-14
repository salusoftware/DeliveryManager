using DeliveryManager.Domain.Residents.ValueObjects;
using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Domain.Shared.Validation;

namespace DeliveryManager.Domain.Residents;

public class Resident
{
    public Guid Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public Address Address { get; }
    
    //Ef
    private Resident(){}
    
    private Resident(string name, string surname, Address address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Address = address;
    }

    public static Resident Create(string name, string surname, Address address)
    {
        Guard.Required(name, ResidentErrors.NameRequired);
        Guard.MaxLength(name, ResidentErrors.NameMaxLength);

        Guard.Required(surname, ResidentErrors.SurnameRequired);
        Guard.MaxLength(surname, ResidentErrors.SurnameMaxLength);
        
        if (address is null)
            throw new DomainException(ResidentErrors.AddressRequired);

        return new Resident(name, surname, address);
    }

}