using Sushi.Services.ShoppingCartAPI.Models.Dtos;

namespace Sushi.Services.ShoppingCartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateCart(CartDto cartDto);
        Task<CartDto> UpdateCart(CartDto cartDto);
        Task<bool> DeleteCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);

    }
}
