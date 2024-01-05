using FluentValidation;

namespace Ma.API.Validators;

public class CpfValidator: AbstractValidator<string>
{
    public CpfValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .Must(x => x.Length == 11)
            .WithMessage("Cpf must have 11 characters")
            .Must(x => x.All(char.IsDigit))
            .WithMessage("Cpf must have only digits")
            .Must(BeAValidCpf)
            .WithMessage("Cpf is invalid");
    }

    private static bool BeAValidCpf(string cpf)
    {
        // Remove non-numeric characters
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        // Check if the CPF has 11 digits
        if (cpf.Length != 11)
        {
            return false;
        }

        // Validate CPF algorithm
        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var tempCpf = cpf.Substring(0, 9);

        var sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
        }

        var remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        var digit = remainder.ToString();
        tempCpf += digit;

        sum = 0;
        for (var i = 0; i < 10; i++)
        {
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
        }

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        digit += remainder;
        return cpf.EndsWith(digit);
    }
}