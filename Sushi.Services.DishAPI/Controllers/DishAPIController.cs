﻿using Microsoft.AspNetCore.Mvc;
using Sushi.Services.DishAPI.Models.Dtos;
using Sushi.Services.DishAPI.Repository;

namespace Sushi.Services.DishAPI.Controllers
{
    [Route("api/dishes")]
    public class DishAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IDishRepository _repository;

        public DishAPIController(IDishRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> GetAll()
        {
            try
            {
                var dishDtos = await _repository.GetDishes();
                _response.Result = dishDtos;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() }; 
            }
            return _response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> GetById(int id)
        {
            try
            {
                var dishDto = await _repository.GetDishById(id);
                _response.Result = dishDto;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] DishDto dto)
        {
            try
            {
                var dish = await _repository.UpdateDish(dto);
                _response.Result = dish;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Update([FromBody] DishDto dto)
        {
            try
            {
                var dish = await _repository.CreateDish(dto);
                _response.Result = dish;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Update(int dishId)
        {
            try
            {
                var result = await _repository.DeleteDish(dishId);
                _response.Result = result;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}