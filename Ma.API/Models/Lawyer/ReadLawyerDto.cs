using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ma.API.Models.User;
using Newtonsoft.Json;

namespace Ma.API.Models.Lawyer;

public class ReadLawyerDto
{
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(100)]
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    [JsonProperty("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [Required, MaxLength(11)]
    [JsonProperty("cpf")]
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [Required, MaxLength(20)]
    [JsonProperty("oab")]
    [JsonPropertyName("oab")]
    public string Oab { get; set; }

    [JsonProperty("user")]
    [JsonPropertyName("user")]
    public ReadUserDto? User { get; set; }

    [JsonProperty("created_at")]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public ReadLawyerDto(int id, string name, string email, string cpf, string oab, ReadUserDto? user, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
        Oab = oab;
        User = user;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}