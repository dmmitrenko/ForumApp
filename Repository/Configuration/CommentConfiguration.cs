using ForumApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Repository.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasData(
            new Comment
            {
                Id = new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"),
                Text = "Good!",
                PostId = new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                UserId = new Guid("5bd958d5-feb1-4860-aedc-ec40047abc12")
            },
            new Comment
            {
                Id = new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"),
                Text = "Not good!",
                PostId = new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                UserId = new Guid("5bd958d5-feb1-4860-aedc-ec40047abc12")
            });
    }
}
