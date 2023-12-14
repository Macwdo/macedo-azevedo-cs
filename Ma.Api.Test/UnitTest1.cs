using FluentAssertions;
using Ma.API.Controllers.Lawsuits;
using Ma.API.Data;
using Ma.API.Entities;
using Ma.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ma.Api.Test;

public class LawsuitControllerTest
{
    [Fact]
    public async Task GetOnSucessReturns200StatusCode()
    {
        // Arrange
        var mockControllerLog = new Mock<ILogger<LawsuitsController>>();
        var mockControllerRepository = new Mock<IRepository<Lawsuit, int>>();
        mockControllerRepository
            .Setup(r => r.Get())
            .Returns(new List<Lawsuit>()
            {
                new Lawsuit
                {
                    AdversePart = new Registry()
                    {
                        Name = "Teste",
                        Id = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    ResponsibleLawyer = new Lawyer()
                    {
                        Name = "teste",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Id = 1,
                        Cpf = "12345678901",
                        Oab = "123456",
                        Email = "email@email.com",
                    },
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LawsuitCode = "12321"
                }
            });
        // Act
        var controller = new LawsuitsController(mockControllerLog.Object, mockControllerRepository.Object);
        var controllerGet = (OkObjectResult)controller.Get();
        // Assert

        controllerGet.StatusCode.Should().Be(200);
    }
}