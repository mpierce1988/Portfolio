using Portfolio.Services.Project;

namespace Portfolio.Services.Test;

public class ProjectServiceTests
{
    private readonly IProjectService _projectService;
    
    public ProjectServiceTests()
    {
        _projectService = new MockProjectService();
    }

    [Fact]
    public async Task GetProjectsAsync_NoLimit_ReturnsValidResponse()
    {
        // Arrange
        int expectedCount = 3;
        int? limit = null;
        
        // Act
        var result = await _projectService.GetProjectsAsync(limit);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            projects =>
            {
                Assert.NotNull(projects);
                Assert.Equal(expectedCount, projects.Count);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetProjectsAsync_GetProjectsByTag_ReturnsValidResponse()
    {
        // Arrange
        int expectedCount = 1;
        int? limit = null;
        int[] tagIds = new[] {6};
        
        // Act
        var result = await _projectService.GetProjectsAsync(limit, tagIds);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            projects =>
            {
                Assert.NotNull(projects);
                Assert.Equal(expectedCount, projects.Count);
                Assert.Equal(tagIds.First(), projects.First().Tags.First().TagId);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetProjectsAsync_LimitOne_ReturnsValidResponse()
    {
        // Arrange
        int expectedCount = 1;
        int? limit = 1;
        
        // Act
        var result = await _projectService.GetProjectsAsync(limit);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            projects =>
            {
                Assert.NotNull(projects);
                Assert.Equal(expectedCount, projects.Count);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetProjectByIdAsync_ValidId_ReturnsValidResponse()
    {
        // Arrange
        string projectId = "2";
        string expectedTitle = "Project Two";
        
        // Act
        var result = await _projectService.GetProjectByIdAsync(projectId);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            project =>
            {
                Assert.NotNull(project);
                Assert.Equal(expectedTitle, project.Title);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }

    [Fact]
    public async Task GetProjectByIdAsync_InvalidId_ReturnsKeyNotFoundException()
    {
        // Arrange
        string projectId = "999";
        
        // Act
        var result = await _projectService.GetProjectByIdAsync(projectId);
        
        // Assert
        Assert.False(result.IsSuccess);
        
        result.Match(
            _ => Assert.False(true, "Expected failure but got success."),
            error => Assert.IsType<KeyNotFoundException>(error)
        );
    }

    [Fact]
    public async Task GetProjectByAliasAsync_ValidAlias_ReturnsProject()
    {
        // Arrange
        string projectAlias = "project-three";
        string expectedTitle = "Project Three";
        
        // Act
        var result = await _projectService.GetProjectByAliasAsync(projectAlias);
        
        // Assert
        Assert.True(result.IsSuccess);

        result.Match(
            project =>
            {
                Assert.NotNull(project);
                Assert.Equal(expectedTitle, project.Title);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }

    [Fact]
    public async Task GetProjectByAliasAsync_InvalidAlias_ReturnsKeyNotFoundException()
    {
        // Arrange 
        string projectAlias = "non-existent-alias";
        
        // Act
        var result = await _projectService.GetProjectByAliasAsync(projectAlias);
        
        // Assert
        Assert.False(result.IsSuccess);
        result.Match(
            _ => Assert.False(true, "Expected failure but got success."),
            error => Assert.IsType<KeyNotFoundException>(error)
        );
    }
}