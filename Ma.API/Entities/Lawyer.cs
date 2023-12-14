namespace Ma.API.Entities;

public class Lawyer: BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public User? User { get; set; }
    public string Oab { get; set; }

}