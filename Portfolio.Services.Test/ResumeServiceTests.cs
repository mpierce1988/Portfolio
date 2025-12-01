using Portfolio.Models;
using Portfolio.Services.Resume;

namespace Portfolio.Services.Test;

public class ResumeServiceTests
{
    private readonly IResumeService _resumeService;
    
    public ResumeServiceTests(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    [Fact]
    public async Task GetResumeAsync_ShouldReturnResume()
    {
        // Arrange
        int expectedExperienceCount = 3;
        
        // Act
        var result = await _resumeService.GetResumeAsync();
        
        // Assert
        Assert.True(result.IsSuccess);

        result.Match(
            resume =>
            {
                Assert.NotNull(resume);
                Assert.Equal(expectedExperienceCount, resume.Experiences.Count);
            },
            error => Assert.False(true, "Expected success but got an error.")
        );
    }
}