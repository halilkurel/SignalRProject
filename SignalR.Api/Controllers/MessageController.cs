using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer;


namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetAll());
            return Ok(value);
        }




        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto message)
        {
            message.Status = false;
            _messageService.TAdd(_mapper.Map<Message>(message));

            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto message)
        {
            _messageService.TUpdate(_mapper.Map<Message>(message));
            return Ok("Güncellendi");
        }
    }
}
