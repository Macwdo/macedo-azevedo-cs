using Ma.API.Models.Lawyer;
using Ma.API.Models.Registry;

namespace Ma.Api.Test.Fixtures.Dtos;

public static class RegistryDtoFixtures
{

    public static ReadRegistryDto ReadRegistryDtoFixture(int id, ReadLawyerDto? lawyer = null) => new ReadRegistryDto(
        id,
        $"Test Registry Name",
        $"registry.email{id}@mail.com",
        new Uri("https://www.google.com.br"),
        lawyer,
        DateTime.Now,
        DateTime.Now
    );


    public static IEnumerable<ReadRegistryDto> ReadRegistriesDtoFixture(int quantity, bool lawyer=true)
    {
        var lawyers = lawyer ? LawyerDtoFixtures.ReadLawyersDtoFixture(quantity): new List<ReadLawyerDto>();
        var registries = Enumerable.Range(1, quantity + 1).Select(i => ReadRegistryDtoFixture(i, lawyers.ElementAtOrDefault(i)));
        return registries;
    }
}