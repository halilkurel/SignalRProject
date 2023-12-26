using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<ContactListDto>>(_contactService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(ContactCreateDto contact)
        {
            _contactService.TAdd(_mapper.Map<Contact>(contact));
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(ContactUpdateDto contact)
        {
            _contactService.TUpdate(_mapper.Map<Contact>(contact));
            return Ok("Güncellendi");
        }
    }
}
