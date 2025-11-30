using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Utilities;
using Portfolio.Models.Blog;
using Portfolio.Services.Blog;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    // GET api/blogs - Get all blogs with optional limit
    [HttpGet]
    public async Task<IActionResult> GetBlogsAsync([FromQuery] int? limit = null, [FromQuery] int[]? tagIds = null)
    {
        try
        {
            var blogsResult = await _blogService.GetBlogsAsync(limit, tagIds);
            
            return blogsResult.Match<IActionResult>(
                blogs =>  Ok(blogs),
                error => throw error
            );
        }
        catch (Exception e)
        {
            return ProblemUtility.GetProblem(e);
        }
    }

    // GET api/blogs/{id} - Get blog by ID (GUID/string)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogByIdAsync(string id)
    {
        try
        {
            var blogResult = await _blogService.GetBlogByIdAsync(id);

            return blogResult.Match<IActionResult>(
                Ok,
                error => throw error    
            );
        }
        catch (Exception e)
        {
            return ProblemUtility.GetProblem(e);
        }
    }
    
    // GET api/blogs/alias/{alias} - Get blog by alias (string)
    [HttpGet("alias/{alias}")]
    public async Task<IActionResult> GetBlogByAliasAsync(string alias)
    {
        try
        {
            var blogResult = await _blogService.GetBlogByAliasAsync(alias);

            return blogResult.Match<IActionResult>(
                Ok,
                error => throw error    
            );
        }
        catch (Exception e)
        {
            return ProblemUtility.GetProblem(e);
        }
    }
}