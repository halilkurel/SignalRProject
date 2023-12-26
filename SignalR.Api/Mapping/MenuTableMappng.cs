using AutoMapper;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class MenuTableMappng : Profile
    {
        public MenuTableMappng()
        {
            CreateMap<MenuTable,ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,UpdateMenuTableDto>().ReverseMap();
            CreateMap<UpdateMenuTableDto,ResultMenuTableDto>().ReverseMap();
        }
    }
}
