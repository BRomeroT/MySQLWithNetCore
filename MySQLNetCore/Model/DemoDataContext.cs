
using Microsoft.EntityFrameworkCore;

namespace MySQLNetCore.Model
{
    public class DemoDataContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=P@ssw0rd;database=demobd");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
