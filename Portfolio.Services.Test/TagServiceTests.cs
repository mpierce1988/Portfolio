using Portfolio.Services.Tag;

namespace Portfolio.Services.Test;

public class TagServiceTests
{
    private readonly ITagService _tagService;
    
    public TagServiceTests()
    {
        _tagService = new MockTagService();
    }

    [Fact]
    public async Task GetTagsAsync_ReturnsValidResponse()
    {
        // Arrange
        int expectedCount = 9;
        
        // Act
        var result = await _tagService.GetTagsAsync();
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            tagResults =>
            {
                Assert.NotNull(tagResults);
                Assert.Equal(expectedCount, tagResults.Count);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetTagByIdAsync_ValidId_ReturnsValidResponse()
    {
        // Arrange
        int tagId = 4;
        string expectedTagName = "C#";
        
        // Act
        var result = await _tagService.GetTagByIdAsync(tagId);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            tag =>
            {
                Assert.NotNull(tag);
                Assert.Equal(expectedTagName, tag.Name);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }

    [Fact]
    public async Task GetTagByIdAsync_InvalidId_ReturnsError()
    {
        // Arrange
        int tagId = 999;
        
        // Act
        var result = await _tagService.GetTagByIdAsync(tagId);
        
        // Assert
        Assert.False(result.IsSuccess);
        
        result.Match(
            _ => Assert.False(true, "Expected failure but got success"),
            error => Assert.IsType<KeyNotFoundException>(error)
        );
    }
}