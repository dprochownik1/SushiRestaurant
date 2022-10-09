using Sushi.Web.Models.Dtos;

namespace Sushi.Web.Services.Interfaces
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);
        Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null);
        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);
        Task<T> DeleteFromCartAsync<T>(int cartId, string token = null);

    }
}
