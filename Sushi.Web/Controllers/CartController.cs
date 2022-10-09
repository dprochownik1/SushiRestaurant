using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sushi.Web.Models.Dtos;
using Sushi.Web.Services.Interfaces;

namespace Sushi.Web.Controllers
{
    public class CartController : Controller
    {

        private readonly IDishService _dishService;
        private readonly ICartService _cartService;

        public CartController(IDishService dishService, ICartService cartService)
        {
            _dishService = dishService;
            _cartService = cartService;
        }

        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedUser());
        }


        private async Task<CartDto> LoadCartDtoBasedOnLoggedUser()
        {
            var userId = User.Claims.Where(c => c.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.GetCartByUserIdAsync<ResponseDto>(userId, accessToken);

            var cartDto = new CartDto();
            if (response != null && response.IsSuccess)
            {
                cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
            }

            if (cartDto.CartHeader != null)
            {
                foreach (var detail in cartDto.CartDetails)
                {
                    cartDto.CartHeader.OrderTotal += (detail.Dish.Price * detail.Count);
                }
            }
            return cartDto;
        }
    }
}
