using System;
using System.Linq;

using BloggingContext db = new BloggingContext();

Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet"});
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
Blog blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(new Post { Title="Hello, world", Content="I wrote an app using EF Core!"});
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();