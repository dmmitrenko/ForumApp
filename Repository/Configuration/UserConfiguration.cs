using ForumApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                
                Name = "Kateryna",
                Surname = "Filinska",
                Nickname = "filinskaya",
                
                Email = "fil@gmail.com"
            },
            new User
            {
                
                Name = "Serhii",
                Surname = "Dmytrenko",
                Nickname = "dmytrenko",
                
                Email = "dmmytrenko@gmail.com"
            });
    }
}
