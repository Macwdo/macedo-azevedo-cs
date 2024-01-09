using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ma.API.Models.Lawyer;
using Newtonsoft.Json;

namespace Ma.API.Models.Registry;

public class ReadRegistryDto
{
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(100)]
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [Required, EmailAddress, MaxLength(100)]
    [JsonProperty("email")]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonProperty("image")]
    [JsonPropertyName("image")]
    public Uri? Image { get; set; }

    [JsonProperty("responsible_lawyer")]
    [JsonPropertyName("responsible_lawyer")]
    public ReadLawyerDto? LawyerResponsible { get; set; }

    [JsonProperty("created_at")]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public ReadRegistryDto(int id, string name, string? email, Uri? image, ReadLawyerDto? lawyerResponsible, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Image = image;
        LawyerResponsible = lawyerResponsible;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}