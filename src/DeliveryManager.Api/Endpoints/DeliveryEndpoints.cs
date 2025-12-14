using DeliveryManager.Api.DTOs;
using DeliveryManager.Api.Mappings;
using DeliveryManager.Application.Deliveries.Commands;
using MediatR;

namespace DeliveryManager.Api.Endpoints;

public static class DeliveryEndpoints
{
    public static IEndpointRouteBuilder MapDeliveryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/deliveries");
        
        group.MapPost("", async (
            CreateDeliveryDto dto,
            IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var command = dto.ToCommand();
            var result = await mediator.Send(command, ct);
            return result;
        });
        
        return group;
    }
}