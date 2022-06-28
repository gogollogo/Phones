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

        public void DeletePhone(int id)
        {
            var phone = _dbContext
                  .Phones
                  .FirstOrDefault(r => r.Id == id);

            _dbContext.Phones.Remove(phone);
            _dbContext.SaveChanges();
        }

        public PhoneDto GetById(int id)
        {
            var phone = _dbContext.Phones.FirstOrDefault(x => x.Id == id);

            var result = _mapper.Map<PhoneDto>(phone);
            return result;

        }

        public void UpdatePhone(int id, UpdatePhoneDto dto)
        {
            var phone = _dbContext
                   .Phones
                   .FirstOrDefault(r => r.Id == id);

            phone.Description = dto.Description;
            phone.Price = dto.Price;

            _dbContext.SaveChanges();
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
