using Portfolio.Models;
using Portfolio.Models.Blog;
using Exception = System.Exception;

namespace Portfolio.Services.Blog;

public class MockBlogService : IBlogService
{
    private List<Models.Blog.Blog> _blogs =
    [
        new Models.Blog.Blog()
        {
            BlogId = "1",
            Alias = "first-blog",
            Title = "My First Blog",
            Content = "This is the content of my first blog.",
            ImageUrl = "https://example.com/image1.jpg",
            Tags = new List<Models.Tag.Tag> { new Models.Tag.Tag { TagId = 1, Name = "Introduction" } },
            CreatedDate = DateTime.Now.AddDays(-3)
        },
        new Models.Blog.Blog()
        {
            BlogId = "2",
            Alias = "second-blog",
            Title = "My Second Blog",
            Content = "This is the content of my second blog.",
            ImageUrl = "https://example.com/image2.jpg",
            Tags = new List<Models.Tag.Tag> { new Models.Tag.Tag { TagId = 2, Name = "Tech" } },
            CreatedDate = DateTime.Now.AddDays(-2)
        },
        new Models.Blog.Blog()
        {
            BlogId = "3",
            Alias = "third-blog",
            Title = "My Third Blog",
            Content = "This is the content of my third blog.",
            ImageUrl = "https://example.com/image3.jpg",
            Tags = new List<Models.Tag.Tag> { new Models.Tag.Tag { TagId = 3, Name = "Life" } },
            CreatedDate = DateTime.Now.AddDays(-1)
        }
    ];
    
    public async Task<Result<List<BlogDto>, Exception>> GetBlogsAsync(int? limit = null, int[]? tagIds = null)
    {
        try
        {
            IEnumerable<BlogDto> query = _blogs.Select(x => new BlogDto(x)).OrderByDescending(x => x.CreatedDate);

            if (tagIds is not null)
            {
                query = query.Where(blog => blog.Tags.Any(tag => tagIds.Contains(tag.TagId)));
            }
            
            if (limit is > 0)
            {
                query = query.Take(limit.Value);
            }

            return await Task.FromResult(
                query.ToList()
            );
        }
        catch (Exception e)
        {
            return await Task.FromResult(e);
        }
    }

    public async Task<Result<Models.Blog.Blog, Exception>> GetBlogByIdAsync(string blogId)
    {
        try
        {
            Models.Blog.Blog? selectedBlog = _blogs.FirstOrDefault(x => x.BlogId == blogId);
            
            if (selectedBlog == null)
            {
                throw new KeyNotFoundException("Blog not found");
            }
            
            return await Task.FromResult(
                selectedBlog
            );
        }
        catch (Exception e)
        {
            return await Task.FromResult(e);
        }
    }

    public async Task<Result<Models.Blog.Blog, Exception>> GetBlogByAliasAsync(string alias)
    {
        try
        {
            Models.Blog.Blog? selectedBlog = _blogs.FirstOrDefault(x => x.Alias == alias);
            
            if (selectedBlog == null)
            {
                throw new KeyNotFoundException("Blog not found");
            }
            
            return await Task.FromResult(
                selectedBlog
            );
        }
        catch (Exception e)
        {
            return await Task.FromResult(e);
        }
    }
}