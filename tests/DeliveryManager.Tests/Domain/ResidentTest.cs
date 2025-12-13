using DeliveryManager.Domain.Errors;
using DeliveryManager.Domain.Exceptions;
using DeliveryManager.Tests.Builders;
using DeliveryManager.Tests.Core;

namespace DeliveryManager.Tests.Domain;

public class ResidentTest
{

    [Theory(DisplayName = "Não deve criar um morador quando algum campo for informado incorretamente")]
    [MemberData(nameof(ResidentInvalidCase))]
    public void AddressCreate_ShouldThrowDomainException_WhenAnyInvariantIsViolated(GenericInvalidCase<ResidentBuilder> testCase)
    {
        var exception = Assert.Throws<DomainException>(() =>
        {
            var builder = ResidentBuilder.Valid();
            testCase.Mutate(builder);
            builder.Build();
        });
        
        Assert.Equal(testCase.ExpectedError, exception.Message);
    }
    
    [Fact(DisplayName = "Deve criar um morador corretamente")]
    public void ResidentCreate_ShouldCreateResident_WhenDataIsValid()
    {
        var name = "Joao";
        var surname = "Silva";
        
        var resident = ResidentBuilder
            .Valid()
            .WithName(name)
            .WithSurname(surname)
            .Build();
        
        Assert.Equal(name, resident.Name);
        Assert.Equal(surname, resident.Surname);
    }
    
    public static readonly IEnumerable<object[]>  ResidentInvalidCase = ExceptionTestCase.Create(new List<GenericInvalidCase<ResidentBuilder>>{
        new(b => b.WithOutName(), ResidentErrors.NameRequired),
        new(b => b.WithOutAddress(), ResidentErrors.AddressRequired),
        new(b => b.WithOutSurname(), ResidentErrors.SurnameRequired),
    });
}