using Ma.API.Entities;

namespace Ma.Api.Test.Fixtures.Entities;

public static class UserFixture
{
    public static User User (int id)
    {
        return new User
        {
            Id = id,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = $"Name {id}",
            Surname = $"Surname {id}"
        };
    }

    public static IEnumerable<User> Users(int quantity) => Enumerable.Range(0, quantity).Select(User);

}