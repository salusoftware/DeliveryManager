using DeliveryManager.Application.Residents.ReadModels;
using DeliveryManager.Domain.Residents;
using DeliveryManager.Domain.Residents.Repositories;
using DeliveryManager.Domain.Residents.ValueObjects;
using MediatR;

namespace DeliveryManager.Application.Residents.Commands;

public class CreateResidentCommandHandler(IResidentRepository repo) 
    : IRequestHandler<CreateResidentCommand, ResidentReadModel>
{
    public async Task<ResidentReadModel> Handle(CreateResidentCommand command, CancellationToken ct)
    {
        var resident = Resident.Create(
             command.Name,
             command.Surname,
             Address.Create(
                 command.Address.Street,
                 command.Address.Number,
                 command.Address.City,
                 command.Address.State,
                 command.Address.ZipCode
             ));

        await repo.AddResident(resident, ct);
        await repo.CommitAsync(ct);
        
        return new ResidentReadModel(
            resident.Id,
            resident.Name,
            resident.Surname,
            resident.Address.Street,
            resident.Address.City,
            resident.Address.State,
            resident.Address.Number,
            resident.Address.ZipCode
        );
    }
}