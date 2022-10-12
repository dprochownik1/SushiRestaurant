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

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {

            Cart cart = _mapper.Map<Cart>(cartDto);

            //check if product exists in database, if not create it!
            var prodInDb = await _dbContext.Dishes
                .FirstOrDefaultAsync(u => u.DishId == cartDto.CartDetails.FirstOrDefault()
                .DishId);
            if (prodInDb == null)
            {
                _dbContext.Dishes.Add(cart.CartDetails.FirstOrDefault().Dish);
                await _dbContext.SaveChangesAsync();
            }


            //check if header is null
            var cartHeaderFromDb = await _dbContext.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == cart.CartHeader.UserId);

            if (cartHeaderFromDb == null)
            {
                //create header and details
                _dbContext.CartHeaders.Add(cart.CartHeader);
                await _dbContext.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Dish = null;
                _dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                //if header is not null
                //check if details has same product
                var cartDetailsFromDb = await _dbContext.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.DishId == cart.CartDetails.FirstOrDefault().DishId &&
                    u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

                if (cartDetailsFromDb == null)
                {
                    //create details
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Dish = null;
                    _dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    //update the count / cart details
                    cart.CartDetails.FirstOrDefault().Dish = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetailsFromDb.Count;
                    cart.CartDetails.FirstOrDefault().CartDetailsId = cartDetailsFromDb.CartDetailsId;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    _dbContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _dbContext.SaveChangesAsync();
                }
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
                    .Where(cd => cd.CartHeaderId == cartDetails.CartHeaderId).Count();
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
            catch
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

    }
}
