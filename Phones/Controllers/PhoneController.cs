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
    }
}
