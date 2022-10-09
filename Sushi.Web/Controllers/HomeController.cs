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

        public HomeController(ILogger<HomeController> logger, IDishService dishService)
        {
            _logger = logger;
            _dishService = dishService;
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
        public async Task<IActionResult> Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}