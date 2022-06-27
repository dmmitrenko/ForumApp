using System.ComponentModel.DataAnnotations.Schema;

namespace ForumApp.Entities.Models;

public class Comment
{
    [Column("CommentId")]
    public Guid Id { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.Now;
    public DateTime LastChange { get; set; } = DateTime.Now;
    public string? Text { get; set; }

    // navigation props
    [ForeignKey(nameof(Post))]
    public Guid PostId { get; set; }
    public Post? Post { get; set; }

    public Guid UserId { get; set; }
}
