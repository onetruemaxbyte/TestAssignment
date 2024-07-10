using Core.Enitity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Candidate> Candidates { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}