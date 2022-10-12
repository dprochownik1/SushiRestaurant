using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sushi.Web.Models.Dtos;
using Sushi.Web.Services.Interfaces;

namespace Sushi.Web.Controllers
{
    
    public class DishController : Controller
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DishIndex()
        {
            var dishes = new List<DishDto>();
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var response = await _dishService.GetAllDishesAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                dishes = JsonConvert.DeserializeObject<List<DishDto>>(Convert.ToString(response.Result));
            }
            return View(dishes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DishCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishCreate(DishDto dishDto)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _dishService.CreateDishAsync<ResponseDto>(dishDto, accessToken);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }

        public async Task<IActionResult> DishEdit(int dishId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _dishService.GetDishByIdAsync<ResponseDto>(dishId, accessToken);
            if (response != null && response.IsSuccess)
            {
                var dish = JsonConvert.DeserializeObject<DishDto>(Convert.ToString(response.Result));
                return View(dish);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishEdit(DishDto dishDto)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _dishService.UpdateDishAsync<ResponseDto>(dishDto, accessToken);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DishDelete(int dishId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _dishService.GetDishByIdAsync<ResponseDto>(dishId, accessToken);
            if (response != null && response.IsSuccess)
            {
                var dish = JsonConvert.DeserializeObject<DishDto>(Convert.ToString(response.Result));
                return View(dish);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishDelete(DishDto dishDto)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _dishService.DeleteDishAsync<ResponseDto>(dishDto.DishId, accessToken);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }
    }
}
