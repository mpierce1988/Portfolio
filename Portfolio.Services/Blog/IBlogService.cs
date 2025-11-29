using Portfolio.Models;
using Portfolio.Models.Blog;

namespace Portfolio.Services.Blog;

/// <summary>
/// Defines the contract for a blog service that provides methods to retrieve blog data.
/// </summary>
public interface IBlogService
{
    /// <summary>
    /// Retrieves a list of blogs, optionally limited by a specified number.
    /// </summary>
    /// <param name="limit">The maximum number of blogs to retrieve. If null, no limit is applied.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a 
    /// <see cref="Result{TValue, TError}"/> with a list of <see cref="BlogDto"/> on success, or an <see cref="Exception"/> on failure.
    /// </returns>
    public Task<Result<List<BlogDto>, Exception>> GetBlogsAsync(int? limit = null);

    /// <summary>
    /// Retrieves a blog by its unique identifier.
    /// </summary>
    /// <param name="blogId">The unique identifier of the blog.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a 
    /// <see cref="Result{TValue, TError}"/> with a <see cref="Models.Blog.Blog"/> on success, or an <see cref="Exception"/> on failure.
    /// </returns>
    public Task<Result<Models.Blog.Blog, Exception>> GetBlogByIdAsync(string blogId);

    /// <summary>
    /// Retrieves a blog by its alias.
    /// </summary>
    /// <param name="alias">The alias of the blog.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a 
    /// <see cref="Result{TValue, TError}"/> with a <see cref="Models.Blog.Blog"/> on success, or an <see cref="Exception"/> on failure.
    /// </returns>
    public Task<Result<Models.Blog.Blog, Exception>> GetBlogByAliasAsync(string alias);
}