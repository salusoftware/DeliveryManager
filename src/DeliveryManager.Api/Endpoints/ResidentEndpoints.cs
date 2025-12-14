using DeliveryManager.Api.DTOs;
using DeliveryManager.Api.Mappings;
using DeliveryManager.Application.Residents.Commands;
using MediatR;

namespace DeliveryManager.Api.Endpoints;

public static class ResidentEndpoints
{
    public static IEndpointRouteBuilder MapResidentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/residents");
        
        group.MapPost("", async (
            CreateResidentDto dto,
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