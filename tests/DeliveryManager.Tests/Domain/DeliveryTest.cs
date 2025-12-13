using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Tests.Builders;
using DeliveryManager.Tests.Core;

namespace DeliveryManager.Tests.Domain;

public class DeliveryTest
{
    
    [Theory(DisplayName = "Não deve criar uma entrega quando algum campo for informado incorretamente")]
    [MemberData(nameof(DeliveryInvalidCase))]
    public void DeliveryCreate_ShouldThrowDomainException_WhenAnyInvariantIsViolated(GenericInvalidCase<DeliveryBuilder> testCase)
    {
        var exception = Assert.Throws<DomainException>(() =>
        {
            var builder = DeliveryBuilder.Valid();
            testCase.Mutate(builder);
            builder.Build();
        });
        
        Assert.Equal(testCase.ExpectedError, exception.Message);
    }
    
    
    [Fact(DisplayName = "Deve criar um delivery corretamente")]
    public void DeliveryCreate_ShouldCreateDelivery_WhenDataIsValid()
    {
        var deliveryName = "Mouse Gamer";
        
        var delivery = DeliveryBuilder
            .Valid()
            .WithName(deliveryName)
            .Build();
        
        Assert.Equal(deliveryName, delivery.Name);
    }

    public static readonly IEnumerable<object[]>  DeliveryInvalidCase = ExceptionTestCase.Create(new List<GenericInvalidCase<DeliveryBuilder>>{
        new(b => b.WithOutName(), DeliveryErrors.NameRequired),
        new(b =>  b.WithName(new string('X', 256)), DeliveryErrors.NameMaxLength),
        new(b =>  b.WithCarrier(new string('X', 256)), DeliveryErrors.CarrierMaxLength),
        new(b =>  b.WithTrackingCode(new string('X', 256)), DeliveryErrors.TrackingCodeMaxLength),
        new(b =>  b.WithKeyWord(new string('X', 256)), DeliveryErrors.KeyWordMaxLength),
        new(b =>  b.WithOutResidentId(), DeliveryErrors.ResidentIdIsRequired),
    });

}