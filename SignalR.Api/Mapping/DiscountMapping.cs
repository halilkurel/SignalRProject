using AutoMapper;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, DiscountListDto>().ReverseMap();
            CreateMap<Discount, DiscountCreateDto>().ReverseMap();
            CreateMap<Discount, DiscountUpdateDto>().ReverseMap();
            CreateMap<DiscountCreateDto, DiscountUpdateDto>().ReverseMap();
        }
    }
}
