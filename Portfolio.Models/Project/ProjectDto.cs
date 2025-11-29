namespace Portfolio.Models.Project;

public record ProjectDto
{
    public string ProjectId { get; set; } = String.Empty;
    public string Alias { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    public string Link { get; set; } = String.Empty;
    public List<Tag.Tag> Tags { get; set; } = new List<Tag.Tag>();
    
    public DateTime CreatedDate { get; set; } = DateTime.MinValue;

    public ProjectDto()
    {
    }

    public ProjectDto(Project project)
    {
        ProjectId = project.ProjectId;
        Alias = project.Alias;
        Title = project.Title;
        ImageUrl = project.ImageUrl;
        Link = project.Link;
        Tags = project.Tags;
        CreatedDate = project.CreatedDate;
    }
}