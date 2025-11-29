namespace Portfolio.Models.Blog;

public class Blog
{
    public string BlogId { get; set; } = String.Empty;
    public string Alias { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    public List<Tag.Tag> Tags { get; set; } = new List<Tag.Tag>();
}