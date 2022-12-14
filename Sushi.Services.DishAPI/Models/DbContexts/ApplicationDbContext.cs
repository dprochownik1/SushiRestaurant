using Microsoft.EntityFrameworkCore;

namespace Sushi.Services.DishAPI.Models.DbContexts
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
                .HasMaxLength(700);

            modelBuilder.Entity<Dish>()
                .Property(d => d.ImageUrl)
                .HasColumnType("varchar")
                .HasMaxLength(80);

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 1,
                Name = "Wakame Salad",
                Price = 11.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/wakame.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 2,
                Name = "Futomaki",
                Price = 37.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/futomaki.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 3,
                Name = "Uramaki",
                Price = 43.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/Uramaki.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 4,
                Name = "Nigiri",
                Price = 48.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/nigiri.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 5,
                Name = "Wege",
                Price = 28.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/Wege.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 6,
                Name = "Gunkan Maki",
                Price = 28.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/gunkan.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 7,
                Name = "Tempura Roll",
                Price = 42.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/tempura.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 8,
                Name = "Ramen",
                Price = 37.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/ramen.jpg",
                CategoryName = "Sushi"
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 9,
                Name = "Miso Soup",
                Price = 22.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl = "https://sushirestaurant.blob.core.windows.net/images/miso.jpg",
                CategoryName = "Sushi"
            });
           
           
        }
    }
}
