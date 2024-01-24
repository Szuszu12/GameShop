using AutoMapper;
using GameShop.Dto;
using GameShop.Models;

namespace GameShop.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Producer, ProducerDto>();
            CreateMap<ProducerDto, Producer>();
        }
    }
}
