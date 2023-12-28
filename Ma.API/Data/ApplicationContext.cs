using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Microsoft.EntityFrameworkCore;

namespace Ma.API.Data ;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }


    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimeStamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        AddTimeStamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void AddTimeStamps()
    {
        var entities = ChangeTracker
            .Entries()
            .Where(
                x => x is { Entity: BaseEntity, State: EntityState.Added or EntityState.Modified }
            );

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;
            if (entity.State == EntityState.Added)
                ((BaseEntity)entity.Entity).CreatedAt = now;
            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }

    }

    // TODO: Break this into multiple files
    public DbSet<Lawsuit> Lawsuits => Set<Lawsuit>();
    public DbSet<LawsuitFees> LawsuitFees => Set<LawsuitFees>();
    public DbSet<LawsuitFiles> LawsuitFiles => Set<LawsuitFiles>();


    public DbSet<Registry> Registries => Set<Registry>();
    public DbSet<Lawyer> Lawyers => Set<Lawyer>();
    public DbSet<User> Users => Set<User>();
}