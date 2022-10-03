using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sushi.Services.DishAPI.Models;
using Sushi.Services.DishAPI.Models.Dtos;

namespace Sushi.Services.DishAPI.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DishRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DishDto> CreateDish(DishDto dishDto)
        {
            var dish = _mapper.Map<DishDto, Dish>(dishDto);
            _dbContext.Dishes.Add(dish);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Dish, DishDto>(dish);
        }
        public async Task<DishDto> UpdateDish(DishDto dishDto)
        {
            var dish = _mapper.Map<DishDto, Dish>(dishDto);
            _dbContext.Dishes.Update(dish);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Dish, DishDto>(dish);
        }

        public async Task<bool> DeleteDish(int dishId)
        {
            try
            {
                var dish = await _dbContext.Dishes.FirstOrDefaultAsync(d => d.DishId == dishId);
      
                if (dish == null)
                {
                    return false;
                }
                _dbContext.Remove(dish);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<DishDto> GetDishById(int dishId)
        {
            var dish = await _dbContext.Dishes.FirstOrDefaultAsync(d => d.DishId == dishId);
            return _mapper.Map<DishDto>(dish);
        }

        public async Task<IEnumerable<DishDto>> GetDishes()
        {
            var dishList = await _dbContext.Dishes.ToListAsync();
            return _mapper.Map<List<DishDto>>(dishList);
        }

       
    }
}
