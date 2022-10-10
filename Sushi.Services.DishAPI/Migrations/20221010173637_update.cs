using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sushi.Services.DishAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/wakame.jpg", "Wakame Salad", 11.99 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/futomaki.jpg", "Futomaki", 37.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/Uramaki.jpg", "Uramaki", 43.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/nigiri.jpg", "Nigiri", 48.990000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Sushi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "https://sushirestaurant.blob.core.windows.net/images/Wege.jpg", "Wege", 28.989999999999998 },
                    { 6, "Sushi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "https://sushirestaurant.blob.core.windows.net/images/gunkan.jpg", "Gunkan Maki", 28.989999999999998 },
                    { 7, "Sushi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "https://sushirestaurant.blob.core.windows.net/images/tempura.jpg", "Tempura Roll", 42.990000000000002 },
                    { 8, "Sushi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "https://sushirestaurant.blob.core.windows.net/images/ramen.jpg", "Ramen", 37.990000000000002 },
                    { 9, "Sushi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "https://sushirestaurant.blob.core.windows.net/images/miso.jpg", "Miso Soup", 22.989999999999998 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/futomaki.jpg", "Futomaki", 37.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/Uramaki.jpg", "Uramaki", 43.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/nigiri.jpg", "Nigiri", 48.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "https://sushirestaurant.blob.core.windows.net/images/Wege.jpg", "Wege", 28.989999999999998 });
        }
    }
}
