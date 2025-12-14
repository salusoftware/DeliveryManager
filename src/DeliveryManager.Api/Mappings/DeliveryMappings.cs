using DeliveryManager.Api.DTOs;
using DeliveryManager.Application.Deliveries.Commands;

namespace DeliveryManager.Api.Mappings;

public static class DeliveryMappings
{
    public static CreateDeliveryCommand ToCommand(this CreateDeliveryDto dto)
        =>  new(
            dto.Name,
            dto.ResidentId,
            dto.Carrier,
            dto.KeyWord,
            dto.TrackingCode
        );
}