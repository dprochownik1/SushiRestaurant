namespace Sushi.Web.Models.Dtos
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CardHeaderId { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }
        public virtual CartHeaderDto CartHeader { get; set; }
        public virtual DishDto Dish { get; set; }
    }
}
