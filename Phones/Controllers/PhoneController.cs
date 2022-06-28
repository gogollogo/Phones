using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models.PhoneModel;
using Phones.Services;

namespace Phones.Controllers
{
    [ApiController]
    [Route("api/phone")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
           
        }
        [HttpGet]
        public ActionResult<IEnumerable<PhoneDto>> GetAll([FromQuery] PhoneQuery query)
        {
            var phones = _phoneService.GetAll(query);

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
        [HttpPatch("{id}")]
        public ActionResult PatchUpdate([FromBody]JsonPatchDocument phoneUpdateDto, int id)
        {
            _phoneService.PatchUpdatePhone(id, phoneUpdateDto);

            return Ok();

        }
    }
}
