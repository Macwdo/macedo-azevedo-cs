using System.ComponentModel.DataAnnotations;

namespace Ma.API.Entities;

public class RegistryCnpjEntity
{

    public required RegistryEntity Registry { get; set; }

    [Key, Required]
    public int RegistryId { get; set; }

    [StringLength(100), Required]
    public string Cnpj { get; set; } = string.Empty;

}