using Sushi.Web.Models.Dtos;

namespace Sushi.Web.Services.Interfaces
{
    public interface IDishService : IBaseService
    {
        Task<T> GetAllDishesAsync<T>();
        Task<T> GetDishByIdAsync<T>(int dishId);
        Task<T> CreateDishAsync<T>(DishDto dishDto);
        Task<T> UpdateDishAsync<T>(DishDto dishDto);
        Task<T> DeleteDishAsync<T>(int dishId);
    }
}
 