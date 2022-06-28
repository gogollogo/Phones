using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models;
using Phones.Services;

namespace Phones.Controllers
{
    [Route("api/phone")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
           
        }
        [HttpGet]
        public ActionResult<IEnumerable<PhoneDto>> GetAll()
        {
            var phones = _phoneService.GetAll();

            return Ok(phones);
        }
        [HttpPost]
        public ActionResult CreatePhone([FromBody] CreatePhoneDto dto)
        {
            var id = _phoneService.CreatePhone(dto);
            return Created($"/api/phone/{id}", null);
        }
        [HttpGet("{id}")]
        public ActionResult<PhoneDto> Get([FromRoute] int id)
        {
            var phone = _phoneService.GetById(id);

            return Ok(phone);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdatePhoneDto dto, [FromRoute] int id)
        {
            _phoneService.UpdatePhone(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _phoneService.DeletePhone(id);
            return NoContent();
        }
    }
}
