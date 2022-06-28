using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models.BrandModel;
using Phones.Services;

namespace Phones.Controllers
{
    [ApiController]
    [Route("api/brand")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BrandDto>> GetAll()
        {
            var brands = _brandService.GetAll();

            return Ok(brands);
        }
        [HttpPost]
        public ActionResult CreateBrand([FromBody] CreateBrandDto dto)
        {
            var id = _brandService.CreateBrand(dto);
            return Created($"/api/brand/{id}", null);
        }
        [HttpGet("{id}")]
        public ActionResult<BrandDto> Get([FromRoute] int id)
        {
            var phone = _brandService.GetById(id);

            return Ok(phone);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBrandDto dto, [FromRoute] int id)
        {
            _brandService.UpdateBrand(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _brandService.DeleteBrand(id);
            return NoContent();
        }
    }
}
