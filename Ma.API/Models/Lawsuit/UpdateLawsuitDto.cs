using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ma.API.Entities.Lawsuit;
using Newtonsoft.Json;

namespace Ma.API.Models.Lawsuit;

// public record UpdateLawsuitDto(
//     string? LawsuitCode,
//     string? Subject,
//     string? Observation,
//     ELawsuitClientPostion? LawsuitClientPosition,
//     ELawsuitType? LawsuitType,
//     int? ResponsibleLawyerId,
//     int? AdversePartId,
//     int? ClientId,
//     int? IndicatedById,
//     DateTime? InitialDate,
//     DateTime? FinalDate
//     );

public class UpdateLawsuitDto
{
    [MaxLength(30)]
    [JsonProperty("lawsuit_code")]
    [JsonPropertyName("lawsuit_code")]
    public string? LawsuitCode { get; set; }

    [MaxLength(100)]
    [JsonProperty("subject")]
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [MaxLength(500)]
    [JsonProperty("observation")]
    [JsonPropertyName("observation")]
    public string? Observation { get; set; }

    [JsonProperty("lawsuit_client_position")]
    [JsonPropertyName("lawsuit_client_position")]
    public ELawsuitClientPostion? LawsuitClientPosition { get; set; }

    [JsonProperty("lawsuit_type")]
    [JsonPropertyName("lawsuit_type")]
    public ELawsuitType? LawsuitType { get; set; }

    [JsonProperty("responsible_lawyer_id")]
    [JsonPropertyName("responsible_lawyer_id")]
    public int? ResponsibleLawyerId { get; set; }

    [JsonProperty("adverse_part_id")]
    [JsonPropertyName("adverse_part_id")]
    public int? AdversePartId { get; set; }

    [JsonProperty("client_id")]
    [JsonPropertyName("client_id")]
    public int? ClientId { get; set; }

    [JsonProperty("indicated_by_id")]
    [JsonPropertyName("indicated_by_id")]
    public int? IndicatedById { get; set; }

    [JsonProperty("initial_date")]
    [JsonPropertyName("initial_date")]
    public DateTime? InitialDate { get; set; }

    [JsonProperty("final_date")]
    [JsonPropertyName("final_date")]
    public DateTime? FinalDate { get; set; }
}
