using Ma.API.DTOs.User;
using Ma.API.Models.Lawyer;

namespace Ma.Api.Test.Fixtures.Dtos;

public class LawyerDtoFixtures
{
    public static ReadLawyerDto ReadLawyerDtoFixture(int id, ReadUserDto? user) => new ReadLawyerDto(
        id + 1,
        $"Test Lawyer Name",
        $"lawyer.something{id}@email.com",
        $"999.999.999-{id}",
        $"999999",
        user,
        DateTime.Now,
        DateTime.Now
    );

    public static IEnumerable<ReadLawyerDto> ReadLawyersDtoFixture (int quantity, bool user=true)
    {
        var users = user ? UserDtoFixtures.ReadUsersDtoFixture(quantity): new List<ReadUserDto>();
        var lawyers = Enumerable.Range(1, quantity + 1).Select(i => ReadLawyerDtoFixture(i, users.ElementAtOrDefault(i)));
        return lawyers;
    }
}