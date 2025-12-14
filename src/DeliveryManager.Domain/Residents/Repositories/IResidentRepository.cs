namespace DeliveryManager.Domain.Residents.Repositories;

public interface IResidentRepository
{
    Task<Resident> AddResident(Resident resident, CancellationToken cancellationToken);
    Task<IEnumerable<Resident>> GetAllResidents(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}