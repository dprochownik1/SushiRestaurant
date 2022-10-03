﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> DishCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishCreate(DishDto dishDto)
        {
            var response = await _dishService.CreateDishAsync<ResponseDto>(dishDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }

        public async Task<IActionResult> DishEdit(int dishId)
        {
            var response = await _dishService.GetDishByIdAsync<ResponseDto>(dishId);
            if (response != null && response.IsSuccess)
            {
                var dish = JsonConvert.DeserializeObject<DishDto>(Convert.ToString(response.Result));
                return View(dish);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishEdit(DishDto dishDto)
        {
            var response = await _dishService.UpdateDishAsync<ResponseDto>(dishDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }

        public async Task<IActionResult> DishDelete(int dishId)
        {
            var response = await _dishService.GetDishByIdAsync<ResponseDto>(dishId);
            if (response != null && response.IsSuccess)
            {
                var dish = JsonConvert.DeserializeObject<DishDto>(Convert.ToString(response.Result));
                return View(dish);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishDelete(DishDto dishDto)
        {
            var response = await _dishService.DeleteDishAsync<ResponseDto>(dishDto.DishId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(DishIndex));
            }
            return View(dishDto);
        }
    }
}
