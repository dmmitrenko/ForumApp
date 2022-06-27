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
    [ForeignKey(nameof(Blog))]
    public Guid BlogId { get; set; }
    public Blog? Blog { get; set; }

    public Guid UserId { get; set; }
}
