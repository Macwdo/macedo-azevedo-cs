using System.Text.Json.Serialization;
using Ma.API.Entities.Lawsuit;
using Ma.API.Models.Lawyer;
using Ma.API.Models.Registry;
using Newtonsoft.Json;

namespace Ma.API.Models.Lawsuit;

public class ReadLawsuitDto
{
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonProperty("lawsuit_code")]
    [JsonPropertyName("lawsuit_code")]
    public string LawsuitCode { get; set; } = string.Empty;

    [JsonProperty("subject")]
    [JsonPropertyName("subject")]
    public string Subject { get; set; } = string.Empty;

    [JsonProperty("observation")]
    [JsonPropertyName("observation")]
    public string Observation { get; set; } = string.Empty;

    [JsonProperty("lawsuit_client_position")]
    [JsonPropertyName("lawsuit_client_position")]
    public ELawsuitClientPostion LawsuitClientPosition { get; set; }

    [JsonProperty("lawsuit_type")]
    [JsonPropertyName("lawsuit_type")]
    public ELawsuitType LawsuitType { get; set; }

    [JsonProperty("responsible_lawyer")]
    [JsonPropertyName("responsible_lawyer")]
    public required ReadLawyerDto ResponsibleLawyer { get; set; }

    [JsonProperty("adverse_part")]
    [JsonPropertyName("adverse_part")]
    public required ReadRegistryDto AdversePart { get; set; }

    [JsonProperty("client")]
    [JsonPropertyName("client")]
    public required ReadRegistryDto Client { get; set; }

    [JsonProperty("indicated_by")]
    [JsonPropertyName("indicated_by")]
    public ReadRegistryDto? IndicatedBy { get; set; }

    [JsonProperty("initial_date")]
    [JsonPropertyName("initial_date")]
    public DateTime? InitialDate { get; set; }

    [JsonProperty("final_date")]
    [JsonPropertyName("final_date")]
    public DateTime? FinalDate { get; set; }

    [JsonProperty("created_at")]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}

