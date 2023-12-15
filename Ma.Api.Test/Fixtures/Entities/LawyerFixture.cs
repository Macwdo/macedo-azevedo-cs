using Ma.API.Entities;

namespace Ma.Api.Test.Fixtures.Entities;

public static class LawyerFixture
{
    public static Lawyer Lawyer (int id, User? user) => new Lawyer
    {
        Cpf = $"XXX.XXX.XXX-{id}",
        Email = $"lawyer.something{id}@email.com",
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
        var users = user ? UserFixture.Users(quantity): new List<User>();
        var lawyers = Enumerable.Range(0, quantity).Select(i => Lawyer(i, users.ElementAtOrDefault(i)));
        return lawyers;
    }
}