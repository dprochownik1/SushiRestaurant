using Sushi.Services.ShoppingCartAPI.Models.Dtos;

namespace Sushi.Services.ShoppingCartAPI.Repository
{
    public interface IDishRepository
    {
        Task<IEnumerable<DishDto>> GetDishes();
        Task<DishDto> GetDishById(int dishId);
        Task<DishDto> CreateDish(DishDto dishDto);
        Task<DishDto> UpdateDish(DishDto dishDto);
        Task<bool> DeleteDish(int dishId);
    }
}
