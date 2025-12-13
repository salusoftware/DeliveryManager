namespace DeliveryManager.Tests.Core;

public sealed record GenericInvalidCase<T>(
    Action<T> Mutate,
    string ExpectedError);