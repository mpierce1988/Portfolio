using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Utilities;
using Portfolio.Services.Project;
using Portfolio.Services.Tag;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;
    
    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTagsAsync()
    {
        try
        {
            var tagsResult = await _tagService.GetTagsAsync();
            
            return tagsResult.Match<IActionResult>(
                Ok,
                error => throw error
            );
        }
        catch (Exception e)
        {
            return ProblemUtility.GetProblem(e);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagByIdAsync(int id)
    {
        try
        {
            var tagResult = await _tagService.GetTagByIdAsync(id);

            return tagResult.Match<IActionResult>(
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