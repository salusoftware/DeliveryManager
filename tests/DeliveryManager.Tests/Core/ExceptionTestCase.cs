namespace DeliveryManager.Tests.Core;

public static class ExceptionTestCase
{
    public static IEnumerable<object[]> Create<T>(List<T> exceptionTestCases)
#pragma warning disable CS8601 // Possible null reference assignment.
        => exceptionTestCases.Select(c => new object[] { c });
#pragma warning restore CS8601 // Possible null reference assignment.
}