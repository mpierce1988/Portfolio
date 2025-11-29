namespace Portfolio.Models.Project;

public class Project
{
    public string ProjectId { get; set; } = String.Empty;
    public string Alias { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    public string Link { get; set; } = String.Empty;
    public List<Tag.Tag> Tags { get; set; } = new List<Tag.Tag>();
}