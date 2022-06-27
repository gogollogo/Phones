using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phones.Entities;

namespace Phones.Services
{
    public class BrandService : IBrandService
    {
        private readonly PhonesDbContext _dbContext;

        public BrandService(PhonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<IEnumerable<Brand>> GetAll()
        {
            var result = _dbContext.Brands.ToList();

            return result;
        }
    }
}
