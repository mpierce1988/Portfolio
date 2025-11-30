using Portfolio.Models;

namespace Portfolio.Services.Tag;

public interface ITagService
{
    public Task<Result<List<Models.Tag.Tag>, Exception>> GetTagsAsync();
    public Task<Result<Models.Tag.Tag, Exception>> GetTagByIdAsync(int tagId);
}