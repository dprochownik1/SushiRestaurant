using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sushi.Services.ShoppingCartAPI.Models;
using Sushi.Services.ShoppingCartAPI.Models.DbContexts;
using Sushi.Services.ShoppingCartAPI.Models.Dtos;

namespace Sushi.Services.ShoppingCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CartRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _dbContext.CartHeaders
                .FirstOrDefaultAsync(ch => ch.UserId == userId);
            if (cartHeader != null)
            {
                _dbContext.CartDetails.RemoveRange
                    (_dbContext.CartDetails.Where(cd => cd.CartHeaderId == cartHeader.CartHeaderId));
                _dbContext.CartHeaders.Remove(cartHeader);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartDto> CreateCart(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            var dish = await _dbContext.Dishes
                .FirstOrDefaultAsync(d => d.DishId == cartDto.CartDetails.FirstOrDefault().DishId);
            if (dish == null)
            {
                _dbContext.Dishes.Add(cart.CartDetails.FirstOrDefault().Dish);
                await _dbContext.SaveChangesAsync();
            }

            var cartHeader = await _dbContext.CartHeaders
                .AsNoTracking()
                .FirstOrDefaultAsync(ch => ch.UserId == cart.CartHeader.UserId);
            if (cartHeader == null)
            {
                _dbContext.CartHeaders.Add(cart.CartHeader);
                await _dbContext.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Dish = null;
                _dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _dbContext.SaveChangesAsync();
            }
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> DeleteCart(int cartDetailsId)
        {
            try
            {
                var cartDetails = await _dbContext.CartDetails
                .FirstOrDefaultAsync(cd => cd.CartDetailsId == cartDetailsId);

                var totalCountOfCartItems = _dbContext.CartDetails
                    .Where(cd => cd.CartDetailsId == cartDetailsId).Count();
                _dbContext.CartDetails.Remove(cartDetails);
                if (totalCountOfCartItems == 1)
                {
                    var cartHeader = await _dbContext.CartHeaders
                        .FirstOrDefaultAsync(ch => ch.CartHeaderId == cartDetails.CartHeaderId);
                    _dbContext.CartHeaders.Remove(cartHeader);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            var cart = new Cart()
            {
                CartHeader = await _dbContext.CartHeaders.FirstOrDefaultAsync(ch => ch.UserId == userId)
            };
            cart.CartDetails = _dbContext.CartDetails
                .Where(cd => cd.CartHeaderId == cart.CartHeader.CartHeaderId)
                .Include(cd => cd.Dish);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> UpdateCart(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);

            var dish = await _dbContext.Dishes
                .FirstOrDefaultAsync(d => d.DishId == cartDto.CartDetails.FirstOrDefault().DishId);

            var cartHeader = await _dbContext.CartHeaders
                .AsNoTracking()
                .FirstOrDefaultAsync(ch => ch.UserId == cart.CartHeader.UserId);
            if (cartHeader != null)
            {
                var cartDetails = await _dbContext.CartDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(cd => cd.DishId == cart.CartDetails.FirstOrDefault().DishId &&
                    cd.CartHeaderId == cartHeader.CartHeaderId);
                if (cartDetails == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Dish = null;
                    _dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Count += cartDetails.Count;
                    cart.CartDetails.FirstOrDefault().Dish = null;
                    _dbContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _dbContext.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartDto>(cart);
        }
    }
}
