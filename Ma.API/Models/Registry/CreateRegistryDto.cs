using System.ComponentModel.DataAnnotations;
using Ma.API.Entities;
using Ma.API.Validators;

namespace Ma.API.Models.Registry;

public class CreateRegistryDto
{
    [Required, MinLength(3), MaxLength(100)]
    public string Name { get; set; }

    [EmailAddress, MaxLength(100)]
    public string? Email { get; set; }

    public Uri? Image { get; set; }

    [EntityExistsValidator<LawyerEntity>]
    public int? LawyerResponsibleId { get; set; }

    public CreateRegistryDto(string name, string? email, Uri? image, int? lawyerResponsibleId)
    {
        Name = name;
        Email = email;
        Image = image;
        LawyerResponsibleId = lawyerResponsibleId;
    }
}