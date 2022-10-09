using Microsoft.EntityFrameworkCore;

namespace Sushi.Services.ShoppingCartAPI.Models.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

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
                .HasMaxLength(700);

            modelBuilder.Entity<Dish>()
                .Property(d => d.ImageUrl)
                .HasColumnType("varchar")
                .HasMaxLength(80);

            modelBuilder.Entity<CartHeader>()
                .Property(ch => ch.CouponCode)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            modelBuilder.Entity<CartHeader>()
                .Property(ch => ch.UserId)
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }

    }
}
