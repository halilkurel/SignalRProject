using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<DiscountListDto>>(_discountService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(DiscountCreateDto Discount)
        {
            _discountService.TAdd(_mapper.Map<Discount>(Discount));
            Discount.Status = false;
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(DiscountUpdateDto Discount)
        {
            _discountService.TUpdate(_mapper.Map<Discount>(Discount));
            Discount.Status = false;
            return Ok("Güncellendi");
        }

        [HttpGet("ChangeStatusFalse/{id}")]
        public async Task<IActionResult> ChangeStatusFalse(int id)
        {
            _discountService.TChangeStatusFalse(id);
            return Ok("Durum Değiştirdi");
        }
        [HttpGet("ChangeStatusTrue/{id}")]
        public async Task<IActionResult> ChangeStatusTrue(int id)
        {
            _discountService.TChangeStatusTrue(id);
            return Ok("Durum Değiştirdi");
        }
    }
}
