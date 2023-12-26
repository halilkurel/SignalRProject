using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderManager _sliderService;
        private readonly IMapper _mapper;

		public SliderController( IMapper mapper, ISliderManager sliderService)
		{
			_mapper = mapper;
			_sliderService = sliderService;
		}

		[HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<SliderListDto>>(_sliderService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSlider(SliderCreateDto dto)
        {
            _sliderService.TAdd(_mapper.Map<Slider>(dto));
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSlider(SliderUpdateDto dto)
        {
            _sliderService.TUpdate(_mapper.Map<Slider>(dto));
            return Ok("Güncellendi");
        }
    }
}
