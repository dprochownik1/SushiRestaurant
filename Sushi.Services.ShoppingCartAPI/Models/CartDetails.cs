using System.ComponentModel.DataAnnotations.Schema;

namespace Sushi.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }

        //References
        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        [ForeignKey("DishId")]
        public virtual Dish Dish { get; set; }
    }
}
