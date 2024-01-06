using FluentValidation;
using Ma.API.Models.Lawsuit;

namespace Ma.API.Validators.Lawsuit;

public class UpdateLawsuitDtoValidator: AbstractValidator<UpdateLawsuitDto>
{
    public UpdateLawsuitDtoValidator()
    {
        RuleFor(x => x.LawsuitCode).NotEmpty().WithMessage("The LawsuitCode field is required.");
    }
}