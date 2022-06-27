using Microsoft.AspNetCore.Mvc;
using Phones.Entities;

namespace Phones.Services
{
    public interface IBrandService
    {
        ActionResult<IEnumerable<Brand>> GetAll();
    }
}