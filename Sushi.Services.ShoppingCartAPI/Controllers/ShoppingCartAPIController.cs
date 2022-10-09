using Microsoft.AspNetCore.Mvc;
using Sushi.Services.ShoppingCartAPI.Models.Dtos;
using Sushi.Services.ShoppingCartAPI.Repository;

namespace Sushi.Services.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class ShoppingCartAPIController : Controller
    {
        private readonly ICartRepository _cartRepository;
        protected ResponseDto _responseDto;

        public ShoppingCartAPIController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            this._responseDto = new ResponseDto();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                var cartDto = await _cartRepository.GetCartByUserId(userId);
                _responseDto.Result = cartDto;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                _responseDto.Result = await _cartRepository.CreateCart(cartDto);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                _responseDto.Result = await _cartRepository.UpdateCart(cartDto);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpPost("DeleteCart")]
        public async Task<object> DeleteCart([FromBody] int cardId)
        {
            try
            {
                _responseDto.Result = await _cartRepository.DeleteCart(cardId);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

    }
}
