using Microsoft.AspNetCore.Mvc;

namespace Portfolio.API.Utilities;

public static class ProblemUtility
{
    public static IActionResult GetProblem(Exception exception)
    {
        if (exception is KeyNotFoundException keyNotFoundException)
        {
            return new ObjectResult(new ProblemDetails
            {
                Title = "Not Found",
                Detail = keyNotFoundException.Message,
                Status = StatusCodes.Status404NotFound
            })
            {
                StatusCode = StatusCodes.Status404NotFound
            };
        }
        else
        {
            return new ObjectResult(new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = exception.Message,
                Status = StatusCodes.Status500InternalServerError
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}