using XoXBlogMono.DBModels;
namespace XoXBlogMono.Models;

public class GeneralModel
{
    public IList<Category> Categories { get; set; } = new List<Category>();
    public Category Category { get; set; }
    public IList<Post> Posts { get; set; } = new List<Post>();
    public Post Post { get; set; }
    public IList<User> Users { get; set; } = new List<User>();
}


