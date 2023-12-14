namespace Ma.API.Entities;

public class User: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
}