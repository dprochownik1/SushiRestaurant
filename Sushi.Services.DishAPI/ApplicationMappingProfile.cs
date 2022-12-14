using AutoMapper;
using Sushi.Services.DishAPI.Models;
using Sushi.Services.DishAPI.Models.Dtos;

namespace Sushi.Services.DishAPI
{
    public class ApplicationMappingProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DishDto, Dish>().ReverseMap();
            });
            return mapperConfiguration;
        }
    }
}
