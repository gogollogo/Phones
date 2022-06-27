using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Services;

namespace Phones.Controllers
{
    [Route("api/brand")]
    public class BrandController : ControllerBase
    {
        private readonly BrandService _brandService;

        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetAll()
        {
            var brandsDtos = _brandService.GetAll();

            return Ok(brandsDtos);
        }
    }
}
