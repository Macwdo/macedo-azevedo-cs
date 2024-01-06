using System.ComponentModel.DataAnnotations;
using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Ma.API.Validators;

namespace Ma.API.Models.Lawsuit;

public record CreateLawsuitDto(
    [Required, MaxLength(20)]
    string LawsuitCode,
    [Required, MaxLength(100)]
    string Subject,
    [MaxLength(500)]
    string Observation,
    ELawsuitClientPostion LawsuitClientPosition,
    ELawsuitType LawsuitType,

    [EntityExistsValidator<LawyerEntity>]
    int ResponsibleLawyerId,
    [EntityExistsValidator<RegistryEntity>]
    int AdversePartId,
    [EntityExistsValidator<RegistryEntity>]
    int ClientId,
    [EntityExistsValidator<RegistryEntity>]
    int? IndicatedById,

    DateTime? InitialDate,
    DateTime? FinalDate
) ;

// Generate a json request example use mocked values instead type of a value
