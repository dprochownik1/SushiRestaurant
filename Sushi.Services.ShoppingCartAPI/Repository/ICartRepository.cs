using Sushi.Services.ShoppingCartAPI.Models.Dtos;

namespace Sushi.Services.ShoppingCartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> DeleteCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);

    }
}
