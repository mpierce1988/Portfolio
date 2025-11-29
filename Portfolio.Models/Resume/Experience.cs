namespace Portfolio.Models.Resume;

public class Experience
{
    public string ExperienceId { get; set; } = String.Empty;
    public string JobTitle { get; set; } = String.Empty;
    public string Company { get; set; } = String.Empty;
    public string Location { get; set; } = String.Empty;
    public DateTime StartDate { get; set; } = DateTime.MinValue;
    public DateTime? EndDate { get; set; } = null;
    public string Content { get; set; } = String.Empty;
    public int DisplayOrder { get; set; } = 0;
}