using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public const string SchemaTableName = "__EFMigrationsHistory";
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<Participant> participants { get; set; }
        public DbSet<Questions> questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                        .HasIndex(p => new { p.Email }).IsUnique(true);
            modelBuilder.Entity<Questions>()
                        .Property(f => f.QnInWord).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasIndex(p => new { p.Option1 }).IsUnique();
                entity.HasIndex(p => new { p.Option2 }).IsUnique();
                entity.HasIndex(p => new { p.Option3 }).IsUnique();
                entity.HasIndex(p => new { p.Option4 }).IsUnique();
            });
        }
    }
   
}
