using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Utilities;
using Portfolio.Services.Resume;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumeController : ControllerBase
{
    private readonly IResumeService _resumeService;
    
    public ResumeController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetResume()
    {
        try
        {
            var resumeResult = await _resumeService.GetResumeAsync();
            
            return resumeResult.Match<IActionResult>(
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