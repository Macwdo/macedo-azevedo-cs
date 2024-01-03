using FluentValidation;
using Ma.API.Models.Registry;

namespace Ma.Api.Validators.Registry;

public class CreateRegistryDtoValidator : AbstractValidator<CreateRegistryDto>
{
    public CreateRegistryDtoValidator()
    {
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

        RuleFor(x => x.Image)
            .Must(x => x is null || Uri.IsWellFormedUriString(x.ToString(), UriKind.Absolute))
            .WithMessage("Image must be a valid URI");
    }
}

