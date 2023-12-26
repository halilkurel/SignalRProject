using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider,SliderListDto>().ReverseMap();
            CreateMap<Slider,SliderCreateDto>().ReverseMap();
            CreateMap<Slider,SliderUpdateDto>().ReverseMap();
            CreateMap<SliderListDto,SliderUpdateDto>().ReverseMap();
        }
    }
}
