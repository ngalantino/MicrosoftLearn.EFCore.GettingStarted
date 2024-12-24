using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

// Database context class
public class BloggingContext : DbContext {
    public DbSet<Blog> Blogs { get; set; }  
    public DbSet<Post> Posts { get; set; }
    public string DbPath { get; }

    public BloggingContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite($"Data Source={DbPath}");
}

// Blog entity class - Each instance of the entity class corresponds to a row in that table, and the properties of the class represent the columns.
public class Blog {
    public int BlogId { get; set; }
    public string Url { get; set; }
    public List<Post> Posts { get; } = new List<Post>();
}

// Post entity class
public class Post {
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}