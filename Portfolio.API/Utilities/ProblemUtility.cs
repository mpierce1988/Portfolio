using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.Exceptions;

namespace Portfolio.API.Utilities;

public static class ProblemUtility
{
    public static IActionResult GetProblem(Exception exception)
    {
        if (exception is NotFoundException notFoundException)
        {
            return new ObjectResult(new ProblemDetails
            {
                Title = "Not Found",
                Detail = notFoundException.Message,
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