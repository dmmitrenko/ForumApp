using ForumApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ForumApp.Repository.Configuration;

namespace ForumApp.Repository.Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
    }

    public DbSet<Post>? Blogs { get; set; }
    public DbSet<Comment>? Comments { get; set; }
}
