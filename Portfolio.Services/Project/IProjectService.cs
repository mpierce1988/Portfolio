using Portfolio.Models;
using Portfolio.Models.Project;

namespace Portfolio.Services.Project;

/// <summary>
/// Defines the contract for a service that provides project-related operations.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Asynchronously retrieves a list of projects, with optional filtering by limit and tag IDs.
    /// </summary>
    /// <param name="limit">An optional parameter to limit the number of projects returned.</param>
    /// <param name="tagIds">An optional array of tag IDs to filter the projects.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="Result{T, TError}"/> object, where T is a list of <see cref="ProjectDto"/> 
    /// and TError is an exception.
    /// </returns>
    public Task<Result<List<ProjectDto>, Exception>> GetProjectsAsync(int? limit = null, int[]? tagIds = null);

    /// <summary>
    /// Asynchronously retrieves a project by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the project.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="Result{T, TError}"/> object, where T is a <see cref="Models.Project.Project"/> 
    /// and TError is an exception.
    /// </returns>
    public Task<Result<Models.Project.Project, Exception>> GetProjectByIdAsync(string id);

    /// <summary>
    /// Asynchronously retrieves a project by its alias.
    /// </summary>
    /// <param name="alias">The alias of the project.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="Result{T, TError}"/> object, where T is a <see cref="Models.Project.Project"/> 
    /// and TError is an exception.
    /// </returns>
    public Task<Result<Models.Project.Project, Exception>> GetProjectByAliasAsync(string alias);
}