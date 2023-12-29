using Ma.API.DTOs.User;

namespace Ma.Api.Test.Fixtures.Dtos;

public class UserDtoFixtures
{
    public static ReadUserDto ReadUserDtoFixture (int id)
    {
        return new ReadUserDto
        (
            id,
            $"User Name {id}",
            $"User Surname {id}",
            "test_user@mail.co",
            DateTime.Now,
            DateTime.Now
        );
    }

    public static IEnumerable<ReadUserDto> ReadUsersDtoFixture(int quantity) =>
        Enumerable.Range(1, quantity + 1).Select(ReadUserDtoFixture);

}

