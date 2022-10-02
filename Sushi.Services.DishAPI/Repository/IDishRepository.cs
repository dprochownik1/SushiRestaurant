using Sushi.Services.DishAPI.Models.Dtos;

namespace Sushi.Services.DishAPI.Repository
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
