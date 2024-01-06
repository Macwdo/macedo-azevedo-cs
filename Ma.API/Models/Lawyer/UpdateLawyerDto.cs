using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ma.API.Entities;
using Ma.API.Validators;
using Newtonsoft.Json;

namespace Ma.API.Models.Lawyer;

public class UpdateLawyerDto
{
    [Required, MinLength(3), MaxLength(100)]
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [Required, EmailAddress, MaxLength(100)]
    [JsonProperty("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [Required, MaxLength(11)]
    [JsonProperty("cpf")]
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; } = null!;

    [Required, MaxLength(20)]
    [JsonProperty("oab")]
    [JsonPropertyName("oab")]
    public string Oab { get; set; } = null!;

    [EntityExistsValidator<UserEntity>]
    [JsonProperty("user_id")]
    [JsonPropertyName("user_id")]
    public int? UserId { get; set; }
}