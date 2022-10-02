using System.ComponentModel.DataAnnotations;

namespace Sushi.Services.DishAPI.Models.Dtos
{
    public class DishDto
    {
        [Key]
        public int DishId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
