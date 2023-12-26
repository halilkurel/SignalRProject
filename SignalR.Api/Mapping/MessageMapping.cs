using AutoMapper;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer;

namespace SignalR.Api.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<UpdateMessageDto, ResultMessageDto>().ReverseMap();
        }
    }
}
