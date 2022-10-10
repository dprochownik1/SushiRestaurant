using Sushi.Web.Models;
using Sushi.Web.Models.Dtos;
using Sushi.Web.Services.Interfaces;
using static Sushi.Web.StaticDetails;

namespace Sushi.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = $"{ShoppingCartApiBase}/api/cart/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> DeleteFromCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartId,
                Url = $"{ShoppingCartApiBase}/api/cart/DeleteCart",
                AccessToken = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{ShoppingCartApiBase}/api/cart/GetCart/{userId}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = $"{ShoppingCartApiBase}/api/cart/UpdateCart",
                AccessToken = token
            });
        }
    }
}
