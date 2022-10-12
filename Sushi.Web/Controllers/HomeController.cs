using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sushi.Web.Models;
using Sushi.Web.Models.Dtos;
using Sushi.Web.Services.Interfaces;
using System.Diagnostics;

namespace Sushi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDishService _dishService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger, IDishService dishService, ICartService cartService)
        {
            _logger = logger;
            _dishService = dishService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var dishes = new List<DishDto>();

            var response = await _dishService.GetAllDishesAsync<ResponseDto>(string.Empty);
            if (response != null && response.IsSuccess)
            {
                dishes = JsonConvert.DeserializeObject<List<DishDto>>(Convert.ToString(response.Result));
            }
            return View(dishes);
        }

        [Authorize]
        public async Task<IActionResult> Details(int dishId)
        {
            var dish = new DishDto();

            var response = await _dishService.GetDishByIdAsync<ResponseDto>(dishId, string.Empty);
            if (response != null && response.IsSuccess)
            {
                dish = JsonConvert.DeserializeObject<DishDto>(Convert.ToString(response.Result));
            }
            return View(dish);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> DetailsPost(DishDto dishDto)
        {
            var cartDto = new CartDto()
            {
                CartHeader = new CartHeaderDto()
                {
                    UserId = User.Claims.Where(c => c.Type == "sub")?.FirstOrDefault()?.Value,
                }
            };
            var cartDetails = new CartDetailsDto()
            {
                Count = dishDto.Count,
                DishId = dishDto.DishId
            };

            var response = await _dishService.GetDishByIdAsync<ResponseDto>(dishDto.DishId, string.Empty);
            if (response != null && response.IsSuccess)
            {
                cartDetails.Dish = JsonConvert.DeserializeObject<DishDto>(Convert.ToString(response.Result));
            }
            var cartDetailsDtos = new List<CartDetailsDto>();
            cartDetailsDtos.Add(cartDetails);
            cartDto.CartDetails = cartDetailsDtos;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var addToCartResponse = await _cartService.AddToCartAsync<ResponseDto>(cartDto, accessToken);

            if (addToCartResponse != null && addToCartResponse.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(dishDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}