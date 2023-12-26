using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking,BookingListDto>().ReverseMap();
            CreateMap<Booking,BookingCreateDto>().ReverseMap();
            CreateMap<Booking,BookingUpdateDto>().ReverseMap();
            CreateMap<BookingListDto, BookingUpdateDto>().ReverseMap();
        }
    }
}
