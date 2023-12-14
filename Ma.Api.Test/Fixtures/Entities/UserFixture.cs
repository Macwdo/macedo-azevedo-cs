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
            Surname = $"Surname {id}",
            BirthDate = DateTime.Today
        };
    }

    public static IEnumerable<User> Users(int quantity)
    {
        var users = new List<User>();
        for (var i = 0; i < quantity; i++)
        {
            users.Add(User(i));
        }
        return users;
    }

}