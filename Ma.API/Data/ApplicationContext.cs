using Ma.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ma.API.Data ;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Lawsuit> Lawsuits => Set<Lawsuit>();
    public DbSet<User> Users => Set<User>();
}