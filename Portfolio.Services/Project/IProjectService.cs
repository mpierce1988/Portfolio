using Portfolio.Models;
using Portfolio.Models.Project;

namespace Portfolio.Services.Project;

public interface IProjectService
{
    public Task<Result<List<ProjectDto>, Exception>> GetProjectsAsync(int? limit = null);
    public Task<Result<Models.Project.Project, Exception>> GetProjectByIdAsync(string id);
    public Task<Result<Models.Project.Project, Exception>> GetProjectByAliasAsync(string alias);
}