using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NTNP.EFCore.Models.Users
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasData(
                new User() { Id = 1, Name = "nhat", Email = "nhatmytasdu@gmail" },
                new User() { Id = 2, Name = "nhu", Email = "asd@gmail" }
                );
        }
    }
}
