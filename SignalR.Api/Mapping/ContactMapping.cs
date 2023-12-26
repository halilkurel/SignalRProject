using AutoMapper;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact,ContactListDto>().ReverseMap();
            CreateMap<Contact,ContactCreateDto>().ReverseMap();
            CreateMap<Contact,ContactUpdateDto>().ReverseMap();
            CreateMap<ContactListDto,ContactUpdateDto>().ReverseMap();
        }
    }
}
