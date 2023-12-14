using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities.Lawsuit;

public class LawsuitFiles: BaseEntity
{
    public required string FileName { get; set; }
    public required Uri FileUrl { get; set; }

    [ForeignKey("LawsuitId")]
    public int LawsuitId { get; set; }
    public required Lawsuit Lawsuit { get; set; }
}