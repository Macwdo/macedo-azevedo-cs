namespace Ma.API.Entities;

public class Registry: BaseEntity
{
    public string Name { get; set; }
    public Uri? Image { get; set; }
    public Lawyer? LawyerResponsible { get; set; }
}