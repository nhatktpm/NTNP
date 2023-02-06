using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NTNP.EFCore.Models.ApplicationParameters
{
    internal class ApplicationParameterConfig : IEntityTypeConfiguration<ApplicationParameter>
    {
        public void Configure(EntityTypeBuilder<ApplicationParameter> builder)
        {
            builder.ToTable(nameof(ApplicationParameter));
        }
    }
}
