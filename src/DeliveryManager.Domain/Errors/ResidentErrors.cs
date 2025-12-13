namespace DeliveryManager.Domain.Errors;

public static class ResidentErrors
{
    public const string NameRequired = "Resident name is required";
    public const string NameMaxLength = "Max Resident name length is 255";
    public const string SurnameRequired = "Resident surname is required";
    public const string SurnameMaxLength = "Max Resident surname length is 255";
    public const string AddressRequired = "Resident address is required";
}