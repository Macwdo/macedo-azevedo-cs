using System.ComponentModel.DataAnnotations;

namespace Ma.API.Entities;

public class RegistryCnpj
{

    public required Registry Registry { get; set; }

    [Key, Required]
    public int RegistryId { get; set; }

    [StringLength(100), Required]
    public string Cnpj { get; set; } = string.Empty;

}