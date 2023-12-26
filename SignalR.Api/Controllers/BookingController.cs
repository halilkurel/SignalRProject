using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(BookingCreateDto bookingCreateDto)
        {
            Booking booking = new()
            {
                Date = bookingCreateDto.Date,
                Mail = bookingCreateDto.Mail,
                Name = bookingCreateDto.Name,
                PersonCount = bookingCreateDto.PersonCount,
                Phone = bookingCreateDto.Phone,
                Description = "Onay Bekliyor",
            };
            _bookingService.TAdd(booking);
            return Ok(booking);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateBooking(BookingUpdateDto bookingUpdateDto)
        {
            Booking booking = new()
            {
                Date = bookingUpdateDto.Date,
                Mail = bookingUpdateDto.Mail,
                Name = bookingUpdateDto.Name,
                PersonCount = bookingUpdateDto.PersonCount,
                Phone = bookingUpdateDto.Phone,
                BookingId = bookingUpdateDto.BookingId,
                Description=bookingUpdateDto.Description
            };
            _bookingService.TUpdate(booking);
            return Ok("Güncellendi");
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Oaylandı");
        }

		[HttpGet("BookingStatusCansled/{id}")]
		public IActionResult BookingStatusCansled(int id)
		{
			_bookingService.TBookingStatusCansled(id);
			return Ok("Rezervasyon İptal Edildi");
		}


	}
}
