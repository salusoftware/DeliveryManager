using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Tests.Builders;
using DeliveryManager.Tests.Core;

namespace DeliveryManager.Tests.Domain;

public class AddressTest
{
    
    [Theory(DisplayName = "Não deve criar um endereço quando algum campo for informado incorretamente")]
    [MemberData(nameof(AddressInvalidCase))]
    public void AddressCreate_ShouldThrowDomainException_WhenAnyInvariantIsViolated(GenericInvalidCase<AddressBuilder> testCase)
    {
        var exception = Assert.Throws<DomainException>(() =>
        {
            var builder = AddressBuilder.Valid();
            testCase.Mutate(builder);
            builder.Build();
        });
        
        Assert.Equal(testCase.ExpectedError, exception.Message);
    }
    
    [Fact(DisplayName = "Deve criar um endereço corretamente")]
    public void AddressCreate_ShouldCreateAddress_WhenDataIsValid()
    {
        var street = "Rua 1";
        var address = AddressBuilder
            .Valid()
            .WithStreet(street)
            .Build();
        
        Assert.Equal(street, address.Street);
    }

    
    public static readonly IEnumerable<object[]>  AddressInvalidCase = ExceptionTestCase.Create(new List<GenericInvalidCase<AddressBuilder>>{
        new(b => b.WithOutCity(), AddressErrors.CityRequired),
        new(b => b.WithOutState(), AddressErrors.StateRequired),
        new(b => b.WithOutStreet(), AddressErrors.StreetRequired),
        new(b => b.WithOutZipCode(), AddressErrors.ZipCodeRequired),
        new(b => b.WithZipCode("ABC00000"), AddressErrors.ZipCodeInvalidFormat),
        new(b => b.WithInvalidNumber(), AddressErrors.InvalidNumber),
        new(b => b.WithCity(new string('X', 256)), AddressErrors.CityMaxLength),
        new(b => b.WithState(new string('X', 3)), AddressErrors.InvalidState),
        new(b => b.WithStreet(new string('X', 256)), AddressErrors.StreetMaxLength),
    });
}