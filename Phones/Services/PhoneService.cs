using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phones.Entities;

namespace Phones.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly PhonesDbContext _dbContext;

        public PhoneService(PhonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        ActionResult<IEnumerable<Phone>> IPhoneService.GetAll()
        {
            var result = _dbContext.Phones.Include(x => x.Brand).ToList();

            return result;
        }
    }
}
