using System.ComponentModel.DataAnnotations;

namespace Sushi.Services.DishAPI.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
