using Microsoft.EntityFrameworkCore;
using NTNP.EFCore.Models.ApplicationParameters;
using NTNP.EFCore.Models.Users;
using NTNP.EFCore.Models.Vocabularies;

namespace NTNP.EFCore.Context
{
    public class NTNPContext : DbContext
    {
        private readonly string _connectionString;
        public NTNPContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NTNPContext(DbContextOptions<NTNPContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ApplicationParameter> ApplicationParameters { get; set; }
        public DbSet<Vocabulary> Vocabularies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NTNPContext).Assembly);

        }


    }
}
