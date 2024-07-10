using Application.Interfaces;
using Core.Enitity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }
}