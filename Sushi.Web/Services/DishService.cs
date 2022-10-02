using Sushi.Web.Models;
using Sushi.Web.Models.Dtos;
using Sushi.Web.Services.Interfaces;
using static Sushi.Web.StaticDetails;

namespace Sushi.Web.Services
{
    public class DishService : BaseService, IDishService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DishService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateDishAsync<T>(DishDto dishDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = dishDto,
                Url =$"{DishApiBase}/api/dishes",
                AccessToken = string.Empty
            });
        }

        public async Task<T> DeleteDishAsync<T>(int dishId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = $"{DishApiBase}/api/dishes/{dishId}",
                AccessToken = string.Empty
            });
        }

        public async Task<T> GetAllDishesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{DishApiBase}/api/dishes",
                AccessToken = string.Empty
            });
        }

        public async Task<T> GetDishByIdAsync<T>(int dishId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{DishApiBase}/api/dishes/{dishId}",
                AccessToken = string.Empty
            });
        }

        public async Task<T> UpdateDishAsync<T>(DishDto dishDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = dishDto,
                Url = $"{DishApiBase}/api/dishes",
                AccessToken = string.Empty
            });
        }
    }
}
