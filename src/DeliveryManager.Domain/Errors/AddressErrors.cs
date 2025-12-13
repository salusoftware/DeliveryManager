namespace DeliveryManager.Domain.Errors;

public static class AddressErrors
{
    public const string StreetRequired = "Street is required";
    public const string StreetMaxLength = "Max Street length is 255";
    public const string CityRequired = "City is required";
    public const string CityMaxLength   = "Max City length is 255";
    public const string StateRequired = "State is required";
    public const string InvalidState  = "Invalid state";
    public const string ZipCodeRequired = "Zip Code is required";
    public const string ZipCodeInvalidFormat = "Invalid ZipCode format";
    public const string InvalidNumber  = "Number must be greater than zero";
}