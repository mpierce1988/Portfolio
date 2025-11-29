using Portfolio.Services.Blog;

namespace Portfolio.Services.Test;

public class BlogServiceTests
{
    private readonly IBlogService _blogService;

    public BlogServiceTests()
    {
        _blogService = new MockBlogService();
    }
    
    [Fact]
    public async Task GetBlogsAsync_NoLimit_ReturnsValidResponse()
    {
        // Arrange
        int expectedCount = 3;
        int? limit = null;
        
        // Act
        var result = await _blogService.GetBlogsAsync(limit);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            blogs =>
            {
                Assert.NotNull(blogs);
                Assert.Equal(expectedCount, blogs.Count);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetBlogsAsync_LimitOne_ReturnsValidResponse()
    {
        // Arrange
        int expectedCount = 1;
        int? limit = 1;
        
        // Act
        var result = await _blogService.GetBlogsAsync(limit);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            blogs =>
            {
                Assert.NotNull(blogs);
                Assert.Equal(expectedCount, blogs.Count);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }

    [Fact]
    public async Task GetBlogByIdAsync_ValidId_ReturnsBlog()
    {
        // Arrange
        string blogId = "1";
        
        // Act
        var result = await _blogService.GetBlogByIdAsync(blogId);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            blog =>
            {
                Assert.NotNull(blog);
                Assert.Equal(blogId, blog.BlogId);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetBlogByIdAsync_InvalidId_ReturnsKeyNotFoundException()
    {
        // Arrange
        string blogId = "1000";
        
        // Act
        var result = await _blogService.GetBlogByIdAsync(blogId);
        
        // Assert
        Assert.True(result.IsError);

        result.Match(
            blog => Assert.False(true, "Expected error but got success"),
            error => Assert.IsType<KeyNotFoundException>(error)
            );
    }
    
    [Fact]
    public async Task GetBlogByAliasAsync_ValidAlias_ReturnsBlog()
    {
        // Arrange
        string alias = "first-blog";
        
        // Act
        var result = await _blogService.GetBlogByAliasAsync(alias);
        
        // Assert
        Assert.True(result.IsSuccess);
        
        result.Match(
            blog =>
            {
                Assert.NotNull(blog);
                Assert.Equal(alias, blog.Alias);
            },
            error => Assert.False(true, $"Expected success but got error: {error.Message}")
        );
    }
    
    [Fact]
    public async Task GetBlogByAliasAsync_InvalidAlias_ReturnsKeyNotFoundException()
    {
        // Arrange
        string alias = "hundredth-blog";
        
        // Act
        var result = await _blogService.GetBlogByAliasAsync(alias);
        
        // Assert
        Assert.True(result.IsError);

        result.Match(
            blog => Assert.False(true, "Expected error but got success"),
            error => Assert.IsType<KeyNotFoundException>(error)
        );
    }
}
