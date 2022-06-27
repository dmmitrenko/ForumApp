using ForumApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Repository.Configuration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasMany(n => n.Comments)
            .WithOne(o => o.Blog)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
        new Blog
        {
            Id = new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
            Title = "About me",
            Text = "Bye world!"
        },

        new Blog
        {
            Id = new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
            Title = "About me",
            Text = "Hello world!",
        }
        );
    }
}
