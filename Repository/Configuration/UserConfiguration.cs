using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e"),
                    Name = "Kateryna",
                    Surname = "Filinska",
                    Nickname = "filinskaya"
                },
                new User
                {
                    Id = new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"),
                    Name = "Serhii",
                    Surname = "Dmytrenko",
                    Nickname = "dmytrenko"
                });
        }
    }
}
