using Portfolio.Models;
using Portfolio.Models.Resume;

namespace Portfolio.Services.Resume;

public class MockResumeService : IResumeService
{
    private static List<Experience> _experiences = new List<Experience>()
    {
        new Experience()
        {
            ExperienceId = "1",
            JobTitle = "Software Engineer",
            Company = "Tech Corp",
            Location = "New York, NY",
            StartDate = new DateTime(2020, 1, 1),
            EndDate = null,
            Content = "Developed various applications using C# and .NET.",
            DisplayOrder = 1
        },
        new Experience()
        {
            ExperienceId = "2",
            JobTitle = "Junior Developer",
            Company = "Web Solutions",
            Location = "San Francisco, CA",
            StartDate = new DateTime(2018, 6, 1),
            EndDate = new DateTime(2019, 12, 31),
            Content = "Assisted in the development of web applications using JavaScript and React.",
            DisplayOrder = 2
        },
        new Experience()
        {
            ExperienceId = "3",
            JobTitle = "Intern",
            Company = "Startup Inc.",
            Location = "Austin, TX",
            StartDate = new DateTime(2017, 5, 1),
            EndDate = new DateTime(2017, 8, 31),
            Content = "Worked on various projects and gained experience in software development.",
            DisplayOrder = 3
        }
    };

    private static Models.Resume.Resume _resume = new()
    {
        CurrentLocation = "Moncton, NB",
        Experiences = _experiences
    };
    
    public async Task<Result<Models.Resume.Resume, Exception>> GetResumeAsync()
    {
        try
        {
            await Task.Delay(50); // Simulate async operation
            return await Task.FromResult(_resume);
        }
        catch (Exception e)
        {
            return e;
        }
    }
}