using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetBlogsAsync([FromQuery] int? limit = null)
    {
        try
        {
            var blogsResult = await _blogService.GetBlogsAsync(limit);
            
            return blogsResult.Match<IActionResult>(
                blogs =>  Ok(blogs),
                error => Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError)
            );
        }
        catch (Exception e)
        {
            return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
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
                error => Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError)    
            );
        }
        catch (Exception e)
        {
            return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
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
                error => Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError)    
            );
        }
        catch (Exception e)
        {
            return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}