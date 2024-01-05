using System.ComponentModel.DataAnnotations;
using Ma.API.DTOs.User;
using Ma.API.Validators;

namespace Ma.API.Models.Lawyer;

public record CreateLawyerDto(
    [MinLength(3), MaxLength(100)]
    string Name,
    [EmailAddress, MaxLength(100)]
    string Email,
    [Required, MaxLength(11)]
    string Cpf,
    [Required, MaxLength(20)]
    string Oab,
    [EntityExistsValidator<Entities.User>]
    int? UserId
);
