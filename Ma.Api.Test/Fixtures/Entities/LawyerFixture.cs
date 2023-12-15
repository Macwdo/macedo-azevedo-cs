using Ma.API.Entities;

namespace Ma.Api.Test.Fixtures.Entities;

public static class LawyerFixture
{
    public static Lawyer Lawyer (int id, User? user) => new Lawyer
    {
        Cpf = $"XXX.XXX.XXX-{id}",
        Email = $"daniel.macedo{id}@email.com",
        Name = $"Lawyer {id}",
        Oab = $"XXXXXX-{id}",
        Id = id,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        User = user,
        UserId = user?.Id
    };

    public static IEnumerable<Lawyer> Lawyers (int quantity, bool user=true)
    {
        var lawyers = new List<Lawyer>();
        if (user)
        {
            var users = UserFixture.Users(quantity).ToList();

        }

        for (var i = 0; i < quantity; i++)
        {
            lawyers.Add(Lawyer(i, users[i]));
        }

        return lawyers;
    }
}