using Portfolio.Models;

namespace Portfolio.Services.Tag;

/// <summary>
/// Defines the contract for a service that provides tag-related operations.
/// </summary>
public interface ITagService
{
    /// <summary>
    /// Asynchronously retrieves a list of tags.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="Result{T, TError}"/> object, where T is a list of <see cref="Models.Tag.Tag"/>
    /// and TError is an exception.
    /// </returns>
    public Task<Result<List<Models.Tag.Tag>, Exception>> GetTagsAsync();

    /// <summary>
    /// Asynchronously retrieves a tag by its unique identifier.
    /// </summary>
    /// <param name="tagId">The unique identifier of the tag.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="Result{T, TError}"/> object, where T is a <see cref="Models.Tag.Tag"/>
    /// and TError is an exception.
    /// </returns>
    public Task<Result<Models.Tag.Tag, Exception>> GetTagByIdAsync(int tagId);
}