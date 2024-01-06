using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ma.API.Data ;

public class ApplicationContext: IdentityDbContext
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
    public DbSet<LawsuitEntity> Lawsuits => Set<LawsuitEntity>();
    public DbSet<LawsuitFeesEntity> LawsuitFees => Set<LawsuitFeesEntity>();
    public DbSet<LawsuitFilesEntity> LawsuitFiles => Set<LawsuitFilesEntity>();


    public DbSet<RegistryEntity> Registries => Set<RegistryEntity>();
    public DbSet<LawyerEntity> Lawyers => Set<LawyerEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
}