using Microsoft.EntityFrameworkCore;
using TheGuiXeCho.Web.Entity;

namespace TheGuiXeCho.Web.Data
{
    public class TheGuiXeChoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public TheGuiXeChoDbContext(DbContextOptions<TheGuiXeChoDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
