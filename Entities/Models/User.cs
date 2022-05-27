using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "User surname is a required field.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Nickname is a required field.")]
        [MaxLength(15, ErrorMessage = "Maximum length for nickname is 15 characters.")]
        public string? Nickname { get; set; }

        public DateTime DateRegistration { get { return DateTime.Now; } }
    }
}
