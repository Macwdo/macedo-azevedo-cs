using System.ComponentModel.DataAnnotations;
using Ma.API.Entities;
using Ma.API.Repository;

namespace Ma.API.Validators;

public class EntityExistsValidatorAttribute<TEntity>: ValidationAttribute where TEntity : class
{

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var entityRepository = (IRepository<TEntity>)validationContext.GetService(typeof(IRepository<TEntity>))!;
        var entityId = (int?)value;
        if (entityId is null)
            return ValidationResult.Success;

        var entity = entityRepository.Get(entityId.Value);
        if (entity is null)
            return new ValidationResult($"{entity} by id={entityId} does not exist");

        return ValidationResult.Success;
    }
}