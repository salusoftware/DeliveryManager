using DeliveryManager.Api.DTOs;
using DeliveryManager.Application.Residents.Commands;

namespace DeliveryManager.Api.Mappings;

public static class ResidentMappings
{
    public static CreateResidentCommand ToCommand(this CreateResidentDto dto)
        => new(
            dto.Name,
            dto.Surname,
            new CreateAddressCommand(
                dto.Address.Street,
                dto.Address.City,
                dto.Address.State,
                dto.Address.Number,
                dto.Address.ZipCode
            )
        );
}