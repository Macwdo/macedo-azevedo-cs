using System.ComponentModel.DataAnnotations;

namespace Ma.API.Entities;

public class RegistryCpfEntity
{
    public virtual required RegistryEntity RegistryEntity { get; set; }

    [Key, Required]
    public int RegistryId { get; set; }

    [Required, StringLength(20)]
    public string Cnpj { get; set; } = string.Empty;

}