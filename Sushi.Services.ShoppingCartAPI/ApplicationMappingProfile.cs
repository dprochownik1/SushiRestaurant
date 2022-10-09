using AutoMapper;
using Sushi.Services.ShoppingCartAPI.Models;
using Sushi.Services.ShoppingCartAPI.Models.Dtos;

namespace Sushi.Services.ShoppingCartAPI
{
    public class ApplicationMappingProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DishDto, Dish>().ReverseMap();
                cfg.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                cfg.CreateMap<CartDetailsDto, CartDetails>().ReverseMap();
                cfg.CreateMap<CartDto, Cart>().ReverseMap();
            });
            return mapperConfiguration;
        }
    }
}
