using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Entities.Models;

public class User : IdentityUser
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime DateRegistration { get; set; } = DateTime.Now;

}
