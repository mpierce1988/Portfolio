using Portfolio.Models;
using Portfolio.Models.Project;
using Exception = System.Exception;

namespace Portfolio.Services.Project;

public class MockProjectService : IProjectService
{
    private readonly List<Models.Project.Project> _projects = new()
    {
        new Models.Project.Project
        {
            ProjectId = "1",
            Alias = "project-one",
            Title = "Project One",
            Content = "This is the first project.",
            ImageUrl = "https://example.com/image1.jpg",
            Link = "https://example.com/project1",
            Tags = new List<Models.Tag.Tag>
            {
                new Models.Tag.Tag { TagId = 4, Name = "C#" },
                new Models.Tag.Tag { TagId = 5, Name = ".NET" }
            },
            CreatedDate = DateTime.Now.AddDays(-3)
        },
        new Models.Project.Project
        {
            ProjectId = "2",
            Alias = "project-two",
            Title = "Project Two",
            Content = "This is the second project.",
            ImageUrl = "https://example.com/image2.jpg",
            Link = "https://example.com/project2",
            Tags = new List<Models.Tag.Tag>
            {
                new Models.Tag.Tag { TagId = 6, Name = "JavaScript" },
                new Models.Tag.Tag { TagId = 7, Name = "React" }
            },
            CreatedDate = DateTime.Now.AddDays(-2)
        },
        new Models.Project.Project
        {
            ProjectId = "3",
            Alias = "project-three",
            Title = "Project Three",
            Content = "This is the third project.",
            ImageUrl = "https://example.com/image3.jpg",
            Link = "https://example.com/project3",
            Tags = new List<Models.Tag.Tag>
            {
                new Models.Tag.Tag { TagId = 8, Name = "Python" },
                new Models.Tag.Tag { TagId = 9, Name = "Django" }
            },
            CreatedDate = DateTime.Now.AddDays(-1)
        }
    };
    
    public async Task<Result<List<ProjectDto>, Exception>> GetProjectsAsync(int? limit = null)
    {
        try
        {
            IEnumerable<ProjectDto> query = _projects.Select(x => new ProjectDto(x)).OrderByDescending(x => x.CreatedDate);

            if (limit.HasValue && limit.Value > 0)
            {
                query = query.Take(limit.Value);
            }

            return await Task.FromResult(query.ToList());
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public async Task<Result<Models.Project.Project, Exception>> GetProjectByIdAsync(string id)
    {
        try
        {
            Models.Project.Project? project = _projects.FirstOrDefault(x => x.ProjectId == id);
            
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }
            
            return await Task.FromResult(project);
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public async Task<Result<Models.Project.Project, Exception>> GetProjectByAliasAsync(string alias)
    {
        try
        {
            Models.Project.Project? project = _projects.FirstOrDefault(x => x.Alias == alias);
            
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }
            
            return await Task.FromResult(project);
        }
        catch (Exception e)
        {
            return e;
        }
    }
}