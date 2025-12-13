using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Domain.Shared.Validation;

namespace DeliveryManager.Domain.Delivery;

public class Delivery
{

    public string Name { get; }
    public string? TrackingCode { get; }
    public string? KeyWord { get;}
    public string?  Carrier { get; }
    
    private Delivery(string name, string? carrier, string? keyWord, string? trackingCode)
    {
        
        Guard.Required(name, DeliveryErrors.NameRequired);
        Guard.MaxLength(name, DeliveryErrors.NameMaxLength);
        
        if (!string.IsNullOrEmpty(carrier)) 
            Guard.MaxLength(carrier, DeliveryErrors.CarrierMaxLength);

        if (!string.IsNullOrEmpty(keyWord)) 
            Guard.MaxLength(keyWord, DeliveryErrors.KeyWordMaxLength);
        
        if (!string.IsNullOrEmpty(trackingCode)) 
            Guard.MaxLength(trackingCode, DeliveryErrors.TrackingCodeMaxLength);
        
        Name = name;
        Carrier = string.IsNullOrWhiteSpace(carrier) ? null : carrier;
        KeyWord = string.IsNullOrWhiteSpace(keyWord) ? null : keyWord;
        TrackingCode = string.IsNullOrWhiteSpace(trackingCode) ? null : trackingCode;
    }
    


    public static Delivery Create(string name, string? carrier, string? keyWord,  string? trackingCode)
    {
        return new Delivery(name,  carrier, keyWord, trackingCode);
    }
    
}