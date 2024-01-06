using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Ma.API.Models.User;
public class ReadUserDto
{
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(100)]
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required, MinLength(3), MaxLength(100)]
    [JsonProperty("surname")]
    [JsonPropertyName("surname")]
    public string Surname { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    [JsonProperty("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonProperty("created_at")]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public ReadUserDto(int id, string name, string surname, string email, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}