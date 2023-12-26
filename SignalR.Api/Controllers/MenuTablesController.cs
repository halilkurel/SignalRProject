using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;


        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll());
            return Ok(value);
        }



        [HttpPost]
        public IActionResult CreateCategory(CreateMenuTableDto dto)
        {
            _menuTableService.TAdd(_mapper.Map<MenuTable>(dto));
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateMenuTableDto dto)
        {
            _menuTableService.TUpdate(_mapper.Map<MenuTable>(dto));
            return Ok("Güncellendi");
        }




    }
}
