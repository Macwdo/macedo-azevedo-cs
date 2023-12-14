using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities.Lawsuit;

public class LawsuitFiles: BaseEntity
{
    public string FileName { get; set; }
    public Uri FileUrl { get; set; }

    [ForeignKey("LawsuitId")]
    public int LawsuitId { get; set; }
    public Lawsuit Lawsuit { get; set; }
}