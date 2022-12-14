using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sushi.Services.ShoppingCartAPI.Models
{
    public class Dish
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DishId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
