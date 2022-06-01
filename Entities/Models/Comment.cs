using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Comment
    {
        [Column("CommentId")]
        public Guid Id { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime LastChange { get; set; } = DateTime.Now;
        public string? Text { get; set; }

        // navigation props
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Blog))]
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
