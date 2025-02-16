using System;
using System.Collections.Generic;

namespace XoXBlogMono.DBModels;

public partial class Post
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string Keywords { get; set; } = null!;

    public string BannerImage { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Order { get; set; }

    public sbyte Status { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;
}
