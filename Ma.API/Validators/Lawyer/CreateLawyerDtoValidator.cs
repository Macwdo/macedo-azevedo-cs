using FluentValidation;
using Ma.API.Models.Lawyer;

namespace Ma.API.Validators.Lawyer;

public class CreateLawyerDtoValidator: AbstractValidator<CreateLawyerDto>
{
    public CreateLawyerDtoValidator()
    {

        RuleFor(x => x.Cpf).SetValidator(x => new CpfValidator());

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .WithMessage("Name must have between 3 and 100 characters")
            ;

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100)
            .WithMessage("Email must be a valid email address")
            ;


    }
}