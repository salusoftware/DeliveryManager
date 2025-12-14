using DeliveryManager.Api.DTOs;
using DeliveryManager.Api.Mappings;
using DeliveryManager.Application.Deliveries.Commands;

namespace DeliveryManager.Api.Endpoints;

public static class DeliveryEndpoints
{
    public static IEndpointRouteBuilder MapDeliveryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/deliveries");
        
        group.MapPost("", async (
            CreateDeliveryDto dto,
            CreateDeliveryCommandHandler createDeliveryCommand,
            CancellationToken ct
            ) =>
        {
            var result = await createDeliveryCommand.Handle(dto.ToCommand(), ct);
            return result;
        });
        
        return group;
    }
}