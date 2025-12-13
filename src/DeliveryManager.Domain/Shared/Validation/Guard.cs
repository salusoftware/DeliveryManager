using DeliveryManager.Domain.Exceptions;

namespace DeliveryManager.Domain.Shared.Validation;

public static class Guard
{
    public static void Required(string value, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException(errorMessage);
    }

    public static void MaxLength(string value, string errorMessage, int max = 255)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return;
        if (value.Length > max)
            throw new DomainException(errorMessage);
    }
    
    public static void MinLength(string value, string errorMessage, int min = 3)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return;
        if (value.Length < min)
            throw new DomainException(errorMessage);
    }
}