using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Ma.API.Entities;
using Ma.API.Exceptions;
using Ma.API.Models.Registry;
using Ma.API.Repository;
using Ma.API.Services;
using Ma.Api.Test.Fixtures.Entities;
using Ma.Api.Validators.Registry;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ma.Api.Test.System.UnitTests.Services;

public class RegistryServiceTest
{

    private ReadRegistryDto MapRegistryToReadRegistryDto(RegistryEntity registryEntity)
    {
        return new ReadRegistryDto(
            registryEntity.Id,
            registryEntity.Name,
            registryEntity.Email,
            registryEntity.Image,
            null,
            registryEntity.CreatedAt,
            registryEntity.UpdatedAt
        );
    }

    [Fact]
    public void GetRegistry_OnSuccess_ReturnsReadRegistryDto()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns(registryFixture);

        var readRegistryDtoFixture = MapRegistryToReadRegistryDto(registryFixture);

        var mockAutoMapper = new Mock<IMapper>();
        mockAutoMapper
            .Setup(a => a.Map<ReadRegistryDto>(registryFixture))
            .Returns(readRegistryDtoFixture);

        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );

        // Act
        var readRegistryDto = registryService.GetRegistry(1);

        // Assert
        readRegistryDto.Should().Be(readRegistryDtoFixture);

    }

    [Fact]
    public void GetRegistry_OnNotFound_ReturnsNull()
    {
        // Arrange
        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns((RegistryEntity?)null);

        var mockAutoMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );

        // Act
        var getRegistryResult = registryService.GetRegistry(1);

        // Assert
        getRegistryResult.Should().BeNull();

    }

    [Fact]
    public void GetRegistries_OnSuccess_ReturnsReadRegistryDtoList()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.GetAllReadOnly())
            .Returns(new List<RegistryEntity> { registryFixture });

        var readRegistryDtoFixture = MapRegistryToReadRegistryDto(registryFixture);

        var mockAutoMapper = new Mock<IMapper>();
        mockAutoMapper
            .Setup(a =>
                a.Map<IEnumerable<ReadRegistryDto>>(new List<RegistryEntity> { registryFixture })
                )
            .Returns(new List<ReadRegistryDto> { readRegistryDtoFixture });

        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );
        // Act
        var readRegistryDtoList = registryService.GetRegistries();

        // Assert
        readRegistryDtoList.Should().BeEquivalentTo(new List<ReadRegistryDto> { readRegistryDtoFixture });

    }

    [Fact]
    public void CreateRegistry_OnSuccess_ReturnsReadRegistryDto()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Create(registryFixture))
            .Returns(registryFixture);

        var createRegistryDtoFixture = new CreateRegistryDto(
            registryFixture.Name,
            registryFixture.Email,
            registryFixture.Image,
            null
        );

        var readRegistryDtoFixture = MapRegistryToReadRegistryDto(registryFixture);

        var mockAutoMapper = new Mock<IMapper>();

        mockAutoMapper
            .Setup(a => a.Map<RegistryEntity>(createRegistryDtoFixture))
            .Returns(registryFixture);

        mockAutoMapper
            .Setup(a => a.Map<ReadRegistryDto>(registryFixture))
            .Returns(readRegistryDtoFixture);

        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new CreateRegistryDtoValidator();

        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator
        );

        // Act
        var readRegistryDto = registryService.CreateRegistry(createRegistryDtoFixture);

        // Assert
        readRegistryDto.Should().Be(readRegistryDtoFixture);

    }

    [Theory]
    [InlineData("Valid Name", "valid_email@mail.com", "https://validimageurl.com/", true)]
    [InlineData("in", "notvalidemail", "https://validimageurl.com/", false)]
    public void CreateRegistry_OnRightFields_ShouldCreate(string name, string email, string image, bool valid)
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        registryFixture.Name = name;
        registryFixture.Email = email;
        registryFixture.Image = new (image);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Create(registryFixture))
            .Returns(registryFixture);

        var createRegistryDtoFixture = new CreateRegistryDto(
            registryFixture.Name,
            registryFixture.Email,
            registryFixture.Image,
            null
        );

        var readRegistryDtoFixture = MapRegistryToReadRegistryDto(registryFixture);

        var mockAutoMapper = new Mock<IMapper>();
        mockAutoMapper
            .Setup(a => a.Map<RegistryEntity>(createRegistryDtoFixture))
            .Returns(registryFixture);

        mockAutoMapper
            .Setup(a => a.Map<ReadRegistryDto>(registryFixture))
            .Returns(readRegistryDtoFixture);

        var mockLogger = new Mock<ILogger<RegistryService>>();
        var validator = new CreateRegistryDtoValidator();
        
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            validator
        );

        // Act
        Action createRegistryAction = () => registryService.CreateRegistry(createRegistryDtoFixture);

        // Assert
        if (valid)
            createRegistryAction.Should().NotThrow();
        else
            createRegistryAction.Should().Throw<InvalidModelException>();
    }

    [Fact]
    public void DeleteRegistry_WhenExists_ShouldNotThrow()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns(registryFixture);

        var mockAutoMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );

        // Act
        Action deleteRegistryAction = () => registryService.DeleteRegistry(1);

        // Assert
        deleteRegistryAction.Should().NotThrow();
    }

    [Fact]
    public void UpdateRegistry_WhenNotExists_ShouldThrow()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns((RegistryEntity?)null);

        var updateRegistryDtoFixture = new UpdateRegistryDto(
            registryFixture.Name,
            registryFixture.Email,
            registryFixture.Image,
            null
        );

        var mockAutoMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );

        // Act
        Action updateRegistryAction = () => registryService.UpdateRegistry(1, updateRegistryDtoFixture);

        // Assert
        updateRegistryAction.Should().Throw<NotFoundEntityException>();
    }

    [Fact]
    public void UpdateRegistry_WhenExists_ShouldUpdate()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns(registryFixture);

        var updateRegistryDtoFixture = new UpdateRegistryDto(
            $"{registryFixture.Name} Updated",
            $"email.update@mail.com",
            registryFixture.Image,
            null
        );

        registryFixture.Name = updateRegistryDtoFixture.Name!;
        registryFixture.Email = updateRegistryDtoFixture.Email;

        mockRegistryRepository
            .Setup(x => x.Update(registryFixture))
            .Returns(registryFixture);

        var mockAutoMapper = new Mock<IMapper>();
        mockAutoMapper
            .Setup(a => a.Map(updateRegistryDtoFixture, registryFixture))
            .Returns(registryFixture);

        mockAutoMapper.
            Setup(a => a.Map<ReadRegistryDto>(registryFixture))
            .Returns(MapRegistryToReadRegistryDto(registryFixture));

        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );

        // Act
        var updatedRegistry = registryService.UpdateRegistry(1, updateRegistryDtoFixture);

        // Assert
        updatedRegistry.Name.Should().Be(updateRegistryDtoFixture.Name);
        updatedRegistry.Email.Should().Be(updateRegistryDtoFixture.Email);
    }

    [Fact]
    public void DeleteRegistry_WhenNotFound_ShouldThrow()
    {
        // Arrange
        var registryFixture = RegistryFixture.Registry(1);

        var mockRegistryRepository = new Mock<IRepository<RegistryEntity>>();
        mockRegistryRepository
            .Setup(x => x.Get(1))
            .Returns((RegistryEntity?)null);

        var mockAutoMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<RegistryService>>();
        var mockValidator = new Mock<IValidator<CreateRegistryDto>>();
        var registryService = new RegistryService(
            mockRegistryRepository.Object,
            mockAutoMapper.Object,
            mockLogger.Object,
            mockValidator.Object
        );

        // Act
        Action deleteRegistryAction = () => registryService.DeleteRegistry(1);

        // Assert
        deleteRegistryAction.Should().Throw<NotFoundEntityException>();
    }


}