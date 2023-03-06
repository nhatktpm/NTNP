using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTNP.EFCore.Models.Users;
using System.Xml.Serialization;

namespace NTNP.EFCore.Models.Vocabularies
{
    public class VocabularyConfig : IEntityTypeConfiguration<Vocabulary>
    {
        public void Configure(EntityTypeBuilder<Vocabulary> builder)
        {
            builder.ToTable(nameof(Vocabulary));
            builder.HasData(
                new Vocabulary() { Id = 1, Name = "hello", Transcript = "xin chao", Comment = "this is a comment", CreatedAt = DateTime.UtcNow },
                new Vocabulary() { Id = 2, Name = "what", Transcript = "cai gi", Comment = "this is a comment", CreatedAt = DateTime.UtcNow }); ;
        }
    }
}
