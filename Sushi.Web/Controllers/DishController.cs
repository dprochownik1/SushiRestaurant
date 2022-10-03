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
        public async Task<IActionResult> DishIndex()
        {
            var dishes = new List<DishDto>();
            var response = await _dishService.GetAllDishesAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                dishes = JsonConvert.DeserializeObject<List<DishDto>>(Convert.ToString(response.Result));
            }
            return View(dishes);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DishDto dishDto)
        {
            var response = await _dishService.CreateDishAsync<ResponseDto>(dishDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }
    }
}
