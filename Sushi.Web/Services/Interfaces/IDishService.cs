using Sushi.Web.Models.Dtos;

namespace Sushi.Web.Services.Interfaces
{
    public interface IDishService : IBaseService
    {
        Task<T> GetAllDishesAsync<T>(string token);
        Task<T> GetDishByIdAsync<T>(int dishId, string token);
        Task<T> CreateDishAsync<T>(DishDto dishDto, string token);
        Task<T> UpdateDishAsync<T>(DishDto dishDto, string token);
        Task<T> DeleteDishAsync<T>(int dishId, string token);
    }
}
 