using ForumApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ForumApp.Repository.Configuration;

namespace ForumApp.Repository.Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Comment>? Comments { get; set; }
}
