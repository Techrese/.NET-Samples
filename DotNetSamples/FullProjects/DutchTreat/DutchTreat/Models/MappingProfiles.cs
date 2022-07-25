using AutoMapper;

namespace DutchTreat.Models
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.OrderId, map => map.MapFrom(src => src.Id)).ReverseMap();


            CreateMap<OrderItem, OrderItem>().ReverseMap();
        }
    }
}
