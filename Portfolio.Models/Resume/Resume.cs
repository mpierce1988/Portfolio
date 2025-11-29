namespace Portfolio.Models.Resume;

public class Resume
{
    public string CurrentLocation { get; set; } = String.Empty;
    public List<Experience> Experiences { get; set; } = new List<Experience>();
}