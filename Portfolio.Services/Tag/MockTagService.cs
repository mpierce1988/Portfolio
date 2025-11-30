using Portfolio.Models;
using Exception = System.Exception;

namespace Portfolio.Services.Tag;

public class MockTagService : ITagService
{
    private readonly List<Models.Tag.Tag> _tags = 
        [
            new Models.Tag.Tag() { TagId = 1, Name = "Introduction" },
            new Models.Tag.Tag() { TagId = 2, Name = "Tech" },
            new Models.Tag.Tag() { TagId = 3, Name = "Life" },
            new Models.Tag.Tag { TagId = 4, Name = "C#" },
            new Models.Tag.Tag { TagId = 5, Name = ".NET" },
            new Models.Tag.Tag { TagId = 6, Name = "JavaScript" },
            new Models.Tag.Tag { TagId = 7, Name = "React" },
            new Models.Tag.Tag { TagId = 8, Name = "Python" },
            new Models.Tag.Tag { TagId = 9, Name = "Django" }
        ];
    
    public async Task<Result<List<Models.Tag.Tag>, Exception>> GetTagsAsync()
    {
        try
        {
            return await Task.FromResult(_tags);
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public async Task<Result<Models.Tag.Tag, Exception>> GetTagByIdAsync(int tagId)
    {
        try
        {
            Models.Tag.Tag? tag = _tags.FirstOrDefault(t => t.TagId == tagId);

            if (tag is null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            return await Task.FromResult(tag);
        }
        catch (Exception e)
        {
            return e;
        }
    }
}