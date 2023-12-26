using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.TestimoniallDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<TestimonialListDto>>(_testimonialService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(TestimonialCreateDto Testimonial)
        {
            _testimonialService.TAdd(_mapper.Map<Testimonial>(Testimonial));
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(TestimonialUpdateDto Testimonial)
        {
            _testimonialService.TUpdate(_mapper.Map<Testimonial>(Testimonial));
            return Ok("Güncellendi");
        }
    }
}
