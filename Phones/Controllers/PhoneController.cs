using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}")]
        public ActionResult<PhoneDto> Get([FromRoute] int id)
        {
            var phone = _phoneService.GetById(id);

            return Ok(phone);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreatePhone([FromBody] CreatePhoneDto dto)
        {
            var id = _phoneService.CreatePhone(dto);
            return Created($"/api/phone/{id}", null);
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdatePhoneDto dto, [FromRoute] int id)
        {
            _phoneService.UpdatePhone(id, dto);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _phoneService.DeletePhone(id);
            return NoContent();
        }
        [Authorize]
        [HttpPatch("{id}")]
        public ActionResult PatchUpdate([FromBody]JsonPatchDocument phoneUpdateDto, int id)
        {
            _phoneService.PatchUpdatePhone(id, phoneUpdateDto);

            return Ok();

        }
    }
}
