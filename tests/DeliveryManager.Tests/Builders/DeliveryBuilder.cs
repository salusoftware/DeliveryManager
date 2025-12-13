using DeliveryManager.Domain.Deliveries;

namespace DeliveryManager.Tests.Builders;

public class DeliveryBuilder
{
    private string? _name = "Caixa de som";
    private string? _carrier = "Fake Transportadora";
    private string? _keyWord = "Céu";
    private string? _trackingCode = "TRCODE009988";
    private Guid _residentId = Guid.NewGuid();

    public static DeliveryBuilder Valid()
    {
        return new DeliveryBuilder();
    }

    public DeliveryBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public DeliveryBuilder WithOutName()
    {
        _name = null;
        return this;
    }


    public DeliveryBuilder WithCarrier(string carrier)
    {
        _carrier = carrier;
        return this;
    }
    
    public DeliveryBuilder WithOutCarrier()
    {
        _carrier = null;
        return this;
    }

    public DeliveryBuilder WithKeyWord(string keyWord)
    {
        _keyWord = keyWord;
        return this;
    }

    public DeliveryBuilder WithOutKeyWord()
    {
        _keyWord = null;
        return this;
    }
    
    public DeliveryBuilder WithTrackingCode(string trackingCode)
    {
        _trackingCode = trackingCode;
        return this;
    }
    
    public DeliveryBuilder WithOutTrackingCode()
    {
        _trackingCode = null;
        return this;
    }

    public DeliveryBuilder WithResidentId(Guid residentId)
    {
        _residentId = residentId;
        return this;
    }

    public DeliveryBuilder WithOutResidentId()
    {
        _residentId = Guid.Empty;
        return this;
    }

    public Delivery Build()
    {
        return  Delivery.Create(
#pragma warning disable CS8604 // Possible null reference argument.
            _name,
#pragma warning restore CS8604 // Possible null reference argument.
            _residentId,
            _carrier,
            _keyWord,
            _trackingCode
        );
    }
}