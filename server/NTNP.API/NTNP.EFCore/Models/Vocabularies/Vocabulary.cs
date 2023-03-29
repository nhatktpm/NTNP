using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTNP.EFCore.Models.Vocabularies
{
    public class Vocabulary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column("transcript", TypeName = "varchar(255)")]
        public string Transcript { get; set; }

        [Column("deleted", TypeName = "boolean")]
        public bool Deleted { get; set; }

        [Column("path", TypeName = "text")]
        public string Path { get; set; } = string.Empty;

        [Column("comment", TypeName = "text")]
        public string Comment { get; set; }

        [Column("created")]
        public DateTime CreatedAt { get; set; }
    }
}
