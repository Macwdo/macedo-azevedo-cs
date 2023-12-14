using System.ComponentModel.DataAnnotations;

namespace Ma.API.Entities;

public class RegistryCnpj
{
    public required Registry Registry { get; set; }

    [Required]
    public int RegistryId { get; set; }

    public required string Cnpj { get; set; }

}