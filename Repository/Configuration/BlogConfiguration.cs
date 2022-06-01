using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
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
                    Text = "Bye world!",
                    UserId = new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"),
                },

                new Blog
                {
                    Id = new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                    Title = "About me",
                    Text = "Hello world!",
                    UserId = new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e")
                }
                );
        }
    }
}
