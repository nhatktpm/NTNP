using Microsoft.EntityFrameworkCore;
using NTNP.EFCore.Models.Users;

namespace NTNP.EFCore.Context
{
    public partial class NTNPContext : DbContext
    {
        private readonly string _connectionString;
        public NTNPContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public NTNPContext(DbContextOptions<NTNPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Bookings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NTNPContext).Assembly);
            modelBuilder.HasSequence<int>("AccpacBatchNumberSequence");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
