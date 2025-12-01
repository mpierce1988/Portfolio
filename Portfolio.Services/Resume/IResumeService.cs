using Portfolio.Models;

namespace Portfolio.Services.Resume;

/// <summary>
/// Defines the contract for a service that provides resume-related operations.
/// </summary>
public interface IResumeService
{
    /// <summary>
    /// Asynchronously retrieves the resume.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="Result{T, TError}"/> object, where T is the resume model and TError is an exception.
    /// </returns>
    public Task<Result<Models.Resume.Resume, Exception>> GetResumeAsync();
}