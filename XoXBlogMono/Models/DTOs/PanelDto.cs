using XoXBlogMono.DBModels;

namespace XoXBlogMono.Models.DTOs;

public class PanelDto
{
    public IList<Category> Categories { get; set; } = new List<Category>();
    public IList<Post> Posts { get; set; } = new List<Post>();
    public Category? Category { get; set; }
    public Post? Post { get; set; }
} 