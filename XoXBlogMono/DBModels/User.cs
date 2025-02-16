using System;
using System.Collections.Generic;

namespace XoXBlogMono.DBModels;

public partial class User
{
    public int Id { get; set; }

    public string NameSurname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
