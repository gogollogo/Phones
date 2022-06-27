using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Services;

namespace Phones.Controllers
{
    [Route("api/brand")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetAll()
        {
            var brands = _brandService.GetAll();

            return Ok(brands);
        }
    }
}
