using Microsoft.EntityFrameworkCore;

namespace Sushi.Services.DishAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.CategoryName)
                .HasColumnType("nvarchar")
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(200);

            modelBuilder.Entity<Dish>()
                .Property(d => d.ImageUrl)
                .HasColumnType("varchar")
                .HasMaxLength(80);
        }
    }
}
