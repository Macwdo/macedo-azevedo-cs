using Ma.API.Entities;

namespace Ma.Api.Test.Fixtures.Entities;

public static class RegistryFixture
{
    public static RegistryEntity Registry(int id, LawyerEntity? lawyer=null) => new RegistryEntity
    {
        Id = id,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        Name = "Registry",
        Email = "registry.email@ema.com",
        Image = new Uri("https://www.google.com.br"),
        LawyerResponsible = lawyer,
        LawyerResponsibleId = lawyer?.Id,
    };

    public static IEnumerable<RegistryEntity> Registries(int quantity, bool lawyer=true)
    {
        var lawyers = lawyer ? LawyerFixture.Lawyers(quantity): new List<LawyerEntity>();
        var registries = Enumerable.Range(0, quantity).Select(i => Registry(i, lawyers.ElementAtOrDefault(i)));
        return registries;
    }
}