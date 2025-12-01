using Portfolio.Models.Blog;

namespace Portfolio.Web.Services.BlogService;

public interface IBlogService
{
    public Task<List<BlogDto>> GetBlogsAsync(int? limit = null, int[]? tagIds = null);
    public Task<Blog?> GetBlogByIdAsync(int blogId);
    public Task<Blog?> GetBlogByAliasAsync(string alias);
}