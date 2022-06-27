using ForumApp.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repository.Repositories;

public class ExternalIdentityContext : IdentityDbContext<User>
{
    public ExternalIdentityContext(DbContextOptions options) : base(options)
    {
    }
}
