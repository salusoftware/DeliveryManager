using DeliveryManager.Domain.Residents;
using DeliveryManager.Domain.Residents.Repositories;
using DeliveryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManager.Infrastructure.Repositories;

public class ResidentRepository(DeliveryManagerDbContext context): IResidentRepository
{
    public async Task<Resident> AddResident(Resident resident, CancellationToken ct)
    {
        await context.Residents.AddAsync(resident, ct);
        return resident;
    }

    public async Task<IEnumerable<Resident>> GetAllResidents(CancellationToken ct)
        => await context.Residents.ToListAsync(ct);

    public async Task CommitAsync(CancellationToken ct)
      => await context.SaveChangesAsync(ct);
}