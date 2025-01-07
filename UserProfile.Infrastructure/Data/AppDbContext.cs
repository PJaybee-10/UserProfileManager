using Microsoft.EntityFrameworkCore;
using UserProfile.Core.Entities;

namespace UserProfile.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Age)
                .HasComputedColumnSql("DATEDIFF(YEAR, BirthDate, GETDATE()) - CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, BirthDate, GETDATE()), BirthDate) > GETDATE() THEN 1 ELSE 0 END");
        }
    }
}

