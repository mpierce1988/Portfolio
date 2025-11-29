using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Blog;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetBlogsAsync([FromQuery] int? limit = null)
    {
        try
        {
            var blogsResult = await _blogService.GetBlogsAsync(limit);
            
            IActionResult returnResult = blogsResult.Match<IActionResult>(
                blogs =>  Ok(blogs),
                error => StatusCode(500, error.Message)
            );

            return returnResult;
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}