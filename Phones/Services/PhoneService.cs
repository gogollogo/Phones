using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phones.Entities;
using Phones.Models;

namespace Phones.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly PhonesDbContext _dbContext;
        private readonly IMapper _mapper;

        public PhoneService(PhonesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int CreatePhone(CreatePhoneDto dto)
        {
            var phone = _mapper.Map<Phone>(dto);
           
            _dbContext.Phones.Add(phone);
            _dbContext.SaveChanges();

            return phone.Id;
        }

        ActionResult<IEnumerable<PhoneDto>> IPhoneService.GetAll()
        {
            var phones = _dbContext
                .Phones
                .Include(p=>p.Brand)
                .ToList();
            var phonesDtos = _mapper.Map<List<PhoneDto>>(phones);

            return phonesDtos;
        }
    }
}
