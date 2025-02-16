using System;
using System.Collections.Generic;

namespace XoXBlogMono.DBModels;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Order { get; set; }

    public sbyte Status { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
