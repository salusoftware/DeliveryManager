using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Domain.Shared.Validation;

namespace DeliveryManager.Domain.Delivery;

public class Delivery
{
    public Guid Id { get; }
    public Guid ResidentId { get; }
    public string Name { get; }
    public string? TrackingCode { get; }
    public string? KeyWord { get;}
    public string?  Carrier { get; }
    
    private Delivery(string name, Guid residentId, string? carrier, string? keyWord, string? trackingCode)
    {
        Id = Guid.NewGuid();
        ResidentId = residentId;
        Name = name;
        Carrier = carrier;
        KeyWord = keyWord;
        TrackingCode = trackingCode;
    }
    


    public static Delivery Create(string name, Guid residentId, string? carrier, string? keyWord,  string? trackingCode)
    {
        Guard.Required(name, DeliveryErrors.NameRequired);
        Guard.MaxLength(name, DeliveryErrors.NameMaxLength);
        
        if (!string.IsNullOrEmpty(carrier)) 
            Guard.MaxLength(carrier, DeliveryErrors.CarrierMaxLength);

        if (!string.IsNullOrEmpty(keyWord)) 
            Guard.MaxLength(keyWord, DeliveryErrors.KeyWordMaxLength);
        
        if (!string.IsNullOrEmpty(trackingCode)) 
            Guard.MaxLength(trackingCode, DeliveryErrors.TrackingCodeMaxLength);
        
        if (residentId == Guid.Empty)
            throw new DomainException(DeliveryErrors.ResidentIdIsRequired);
        
        return new Delivery(name, residentId, carrier, keyWord, trackingCode);
    }
    
}