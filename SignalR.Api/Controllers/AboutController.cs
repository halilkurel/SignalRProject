using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(AboutCreateDto aboutCreateDto)
        {
            //AutoMapper kullanılmazsa bu şekilde eşleme yapılmalı
            About dto = new()
            {
                Title = aboutCreateDto.Title,
                Descripetion = aboutCreateDto.Descripetion,
                ImageUrl = aboutCreateDto.ImageUrl
            };
            _aboutService.TAdd(dto);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(AboutUpdateDto aboutUpdateDto)
        {
            About about = new()
            {
                Title = aboutUpdateDto.Title,
                Descripetion = aboutUpdateDto.Descripetion,
                AboutId = aboutUpdateDto.AboutId,
                ImageUrl = aboutUpdateDto.ImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value =_aboutService.TGetById(id);
            return Ok(value);
        }




    }
}
