using AutoMapper;
using Sushi.Services.DishAPI.Dtos;
using Sushi.Services.DishAPI.Models;

namespace Sushi.Services.DishAPI
{
    public class ApplicationMappingProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DishDto, Dish>();
                cfg.CreateMap<Dish, DishDto>();
            });
            return mapperConfiguration;
        }
    }
}
