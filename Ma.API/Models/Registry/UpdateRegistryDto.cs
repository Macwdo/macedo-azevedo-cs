using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ma.API.Entities;
using Ma.API.Validators;
using Newtonsoft.Json;

namespace Ma.API.Models.Registry;

public class UpdateRegistryDto
{
    [Required, MinLength(3), MaxLength(100)]
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    [JsonProperty("email")]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

   //TODO: Validation for Image Uri
    [JsonProperty("image")]
    [JsonPropertyName("image")]
    public Uri? Image { get; set; }

    [EntityExistsValidator<LawyerEntity>]
    [JsonProperty("responsible_lawyer_id")]
    [JsonPropertyName("responsible_lawyer_id")]
    public int? LawyerResponsibleId { get; set; }

    public UpdateRegistryDto(string? name, string? email, Uri? image, int? lawyerResponsibleId)
    {
        Name = name;
        Email = email;
        Image = image;
        LawyerResponsibleId = lawyerResponsibleId;
    }
}