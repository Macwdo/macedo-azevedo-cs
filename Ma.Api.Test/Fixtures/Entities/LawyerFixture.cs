using Ma.API.Entities;

namespace Ma.Api.Test.Fixtures.Entities;

public static class LawyerFixture
{
    public static LawyerEntity Lawyer (int id, UserEntity? user) => new LawyerEntity
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

    public static IEnumerable<LawyerEntity> Lawyers (int quantity, bool user=true)
    {
        var users = user ? UserFixture.Users(quantity): new List<UserEntity>();
        var lawyers = Enumerable.Range(0, quantity).Select(i => Lawyer(i, users.ElementAtOrDefault(i)));
        return lawyers;
    }
}