using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<SocialMediaListDto>>(_socialMediaService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMediaCreateDto SocialMedia)
        {
            _socialMediaService.TAdd(_mapper.Map<SocialMedia>(SocialMedia));
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(SocialMediaUpdateDto SocialMedia)
        {
            _socialMediaService.TUpdate(_mapper.Map<SocialMedia>(SocialMedia));
            return Ok("Güncellendi");
        }
    }
}
