using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Microsoft.EntityFrameworkCore;

namespace Ma.API.Data ;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Lawsuit> Lawsuits => Set<Lawsuit>();

    public DbSet<LawsuitFees> LawsuitFees => Set<LawsuitFees>();
    public DbSet<LawsuitFiles> LawsuitFiles => Set<LawsuitFiles>();


    public DbSet<Registry> Registries => Set<Registry>();
    public DbSet<Lawyer> Lawyers => Set<Lawyer>();
    public DbSet<User> Users => Set<User>();
}