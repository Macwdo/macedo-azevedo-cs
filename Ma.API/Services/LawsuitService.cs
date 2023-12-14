using Ma.API.Data;
using Ma.API.Entities;

namespace Ma.API.Services;

public class LawsuitService
{
    private readonly ApplicationContext _context;
    private ILogger<LawsuitService> _logger;

    public LawsuitService(Logger<LawsuitService> logger)
    {
        _logger = logger;
    }

    public void MakeSomething()
    {
        throw new Exception("Critical error inside service");
    }

    public void CreateUser()
    {
        _context.Users.Add(new User()
        {
            Name = "Teste",
            Surname = "asdasdsa",
            BirthDate = DateTime.Now,
        });
    }
}