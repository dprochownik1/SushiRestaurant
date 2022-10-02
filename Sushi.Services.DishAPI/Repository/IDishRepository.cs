using Sushi.Services.DishAPI.Dtos;

namespace Sushi.Services.DishAPI.Repository
{
    public interface IDishRepository
    {
        Task<IEnumerable<DishDto>> GetDishes();
        Task<DishDto> GetDishById(int dishId);
        Task<DishDto> CreateUpdateDish(DishDto dishDto);
        Task<bool> DeleteDish(int dishId);
    }
}
