using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Project;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProjectsAsync(int? limit = null)
    {
        try
        {
            var projectsResult = await _projectService.GetProjectsAsync(limit);
            
            return projectsResult.Match<IActionResult>(
                projects =>  Ok(projects),
                error => Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError)
            );
        }
        catch (Exception e)
        {
            return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectByIdAsync(string id)
    {
        try
        {
            var projectResult = await _projectService.GetProjectByIdAsync(id);

            return projectResult.Match<IActionResult>(
                Ok,
                error => Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError)
            );
        }
        catch (Exception e)
        {
            return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet("alias/{alias}")]
    public async Task<IActionResult> GetProjectByAliasAsync(string alias)
    {
        try
        {
            var projectResult = await _projectService.GetProjectByAliasAsync(alias);

            return projectResult.Match<IActionResult>(
                Ok,
                error => Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError)    
            );
        }
        catch (Exception e)
        {
            return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}