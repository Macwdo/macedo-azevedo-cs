using FluentValidation;
using Ma.API.Models.Lawsuit;

namespace Ma.API.Validators.Lawsuit;

public class CreateLawsuitDtoValidator: AbstractValidator<CreateLawsuitDto>
{
    public CreateLawsuitDtoValidator()
    {
        RuleFor(x => x.LawsuitCode).NotEmpty().WithMessage("The LawsuitCode field is required.");
    }
}