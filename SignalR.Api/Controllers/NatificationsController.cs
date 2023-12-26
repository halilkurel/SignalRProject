using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.NatificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatificationsController : ControllerBase
    {
        private readonly INatificationService _informationService;

        public NatificationsController(INatificationService informationService)
        {
            _informationService = informationService;
        }

        [HttpGet]
        public IActionResult NatificationList()
        {
            return Ok(_informationService.TGetAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_informationService.NotificationCountByStatusFalse());
        }


        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_informationService.TGetAllNatificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNatificcationDto dto)
        {
            Natification natification = new()
            {
                Status = false,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Description = dto.Description,
                Icon = dto.Icon,
                Type = dto.Type

            };
            _informationService.TAdd(natification);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _informationService.TGetById(id);
            _informationService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNatification(int id)
        {
            var value = _informationService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNatification(UpdateNAtificationDto dto)
        {
            Natification natification = new()
            {
                NatificationId = dto.NatificationId,
                Status = dto.Status,
                Date = dto.Date,
                Description = dto.Description,
                Icon = dto.Icon,
                Type = dto.Type

            };
            _informationService.TUpdate(natification);
            return Ok("Güncellendi");
        }

        [HttpGet("NatificationChangeStatusToFalse/{id}")]
        public IActionResult NatificationChangeStatusToFalse(int id)
        {
            _informationService.TNatificationChangeStatusToFalse(id);
            return Ok("Güncellendi");
        }

        [HttpGet("NatificationChangeStatusToTrue/{id}")]
        public IActionResult NatificationChangeStatusToTrue(int id)
        {
            _informationService.TNatificationChangeStatusToTrue(id);
            return Ok("Güncellendi");
        }



    }
}
