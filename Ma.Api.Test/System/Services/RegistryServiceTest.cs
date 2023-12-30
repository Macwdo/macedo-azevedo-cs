using AutoMapper;
using FluentAssertions;
using Ma.API.Entities;
using Ma.API.Models.Registry;
using Ma.API.Repository;
using Ma.API.Services;
using Ma.Api.Test.Fixtures.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ma.Api.Test.System.Services;

public class RegistryServiceTest
{

    // Refactor
    [Fact]
    public void GetRegistry_OnSuccess_ReturnsReadRegistryDto()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<Registry>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns(registryFixture);

        var readRegistryDtoFixture = new ReadRegistryDto(
            registryFixture.Id,
            registryFixture.Name,
            registryFixture.Email,
            registryFixture.Image,
            null,
            registryFixture.CreatedAt,
            registryFixture.UpdatedAt
        );

        var mockAutoMapper = new Mock<IMapper>();
        mockAutoMapper
            .Setup(a => a.Map<ReadRegistryDto>(registryFixture))
            .Returns(readRegistryDtoFixture);

        var mockLogger = new Mock<ILogger<RegistryService>>();
        var registryService = new RegistryService(mockRegistryRepository.Object, mockAutoMapper.Object, mockLogger.Object);

        // Act
        var readRegistryDto = registryService.GetRegistry(1);

        // Assert
        readRegistryDto.Should().Be(readRegistryDtoFixture);


    }
}