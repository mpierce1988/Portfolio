namespace Portfolio.Models.Blog;

public record BlogDto
{
    public string BlogId { get; set; } = String.Empty;
    public string Alias { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    public List<Tag.Tag> Tags { get; set; } = new List<Tag.Tag>();

    public BlogDto()
    {
    }

    public BlogDto(Blog blog)
    {
        BlogId = blog.BlogId;
        Alias = blog.Alias;
        Title = blog.Title;
        ImageUrl = blog.ImageUrl;
        Tags = blog.Tags;
    }
}