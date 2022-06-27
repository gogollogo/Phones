using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
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
        public ActionResult<IEnumerable<Brand>> GetAll()
        {
            var brandsDtos = _phoneService.GetAll();

            return Ok(brandsDtos);
        }
    }
}
