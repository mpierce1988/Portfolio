namespace Portfolio.Models.Tag;

public record Tag
{
    public int TagId { get; set; }
    public string Name { get; set; } = string.Empty;
}