using AutoMapper;
using SignalR.DtoLayer.TestimoniallDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial,TestimonialListDto>().ReverseMap();
            CreateMap<Testimonial,TestimonialCreateDto>().ReverseMap();
            CreateMap<Testimonial,TestimonialUpdateDto>().ReverseMap();
            CreateMap<TestimonialUpdateDto,TestimonialListDto>().ReverseMap();
        }
    }
}
