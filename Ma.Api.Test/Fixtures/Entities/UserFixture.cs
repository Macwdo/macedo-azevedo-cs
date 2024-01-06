using Ma.API.Entities;

namespace Ma.Api.Test.Fixtures.Entities;

public static class UserFixture
{
    public static UserEntity User (int id)
    {
        return new UserEntity
        {
            Id = id,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = $"Name {id}",
            Surname = $"Surname {id}"
        };
    }

    public static IEnumerable<UserEntity> Users(int quantity) => Enumerable.Range(0, quantity).Select(User);

}