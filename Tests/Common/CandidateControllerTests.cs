using Moq;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using Application.Interfaces;
using Application.DTO;
using Application;

namespace Tests.Common;

public class CandidateControllerTests
{
    private readonly Mock<ICandidateService> _mockCandidateService;
    private readonly CandidateController _controller;

    public CandidateControllerTests()
    {
        _mockCandidateService = new Mock<ICandidateService>();
        _controller = new CandidateController(_mockCandidateService.Object);
    }

    [Fact]
    public async Task CreateOrUpdateCandidate_ReturnsOkResult_WithValidDto()
    {
        // Arrange
        var dto = new CreateOrUpdateCandidateDto
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PreferredCallTimeInterval = DateTime.Now,
            Phone = "1234567890",
            LinkedInProfile = "https://linkedin.com/in/johndoe",
            GithubProfile = "https://github.com/johndoe",
            Comment = "No comment"
        };
        var expectedResult = new IdResult { Id = dto.Id.GetValueOrDefault() };
        _mockCandidateService.Setup(service => service.CreateOrUpdateCandidate(dto))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.CreateOrUpdateCandidate(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<IdResult>(okResult.Value);
        Assert.Equal(expectedResult.Id, returnValue.Id);
    }

    [Fact]
    public async Task CreateOrUpdateCandidate_ReturnsBadRequest_WhenDtoIsNull()
    {
        // Arrange
        CreateOrUpdateCandidateDto dto = null;

        // Act
        var result = await _controller.CreateOrUpdateCandidate(dto);

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Candidate data is null.", badRequestResult.Value);
    }
}