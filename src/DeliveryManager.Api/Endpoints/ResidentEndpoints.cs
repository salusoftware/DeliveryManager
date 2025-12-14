using DeliveryManager.Api.DTOs;
using DeliveryManager.Api.Mappings;
using DeliveryManager.Application.Residents.Commands;

namespace DeliveryManager.Api.Endpoints;

public static class ResidentEndpoints
{
    public static IEndpointRouteBuilder MapResidentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/residents");
        
        group.MapPost("", async (
            CreateResidentDto dto,
            CreateResidentCommandHandler createResidentCommandHandler,
            CancellationToken ct
            ) =>
        {
            var result = await createResidentCommandHandler.Handle(dto.ToCommand(), ct);
            return result;
        });
        
        return group;
    }
}