using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Phones.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Phones.Models.PhoneModel;
using Phones.Models;
using Phones.Exceptions;

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
        PaginationData<PhoneDto> IPhoneService.GetAll(PhoneQuery query)
        {
            var baseQuery = _dbContext
                .Phones
                .Include(p => p.Brand)
                .Where(x=>query.SearchPhrase == null || (x.Name.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columsSelectors = new Dictionary<string, Expression<Func<Phone, object>>>
                {
                    {nameof(Phone.Name), r=>r.Name },
                    {nameof(Phone.Price), r=>r.Price },
                };

                var selectedColumn = columsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }


            var phones = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();
            var totalItemsCount = baseQuery.Count();

            var phonesDtos = _mapper.Map<List<PhoneDto>>(phones);

            var result = new PaginationData<PhoneDto>(phonesDtos, totalItemsCount, query.PageSize, query.PageNumber);
            return result;
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

            if (phone is null)
                throw new NotFoundException("Phone not found");

            _dbContext.Phones.Remove(phone);
            _dbContext.SaveChanges();
        }
        public PhoneDto GetById(int id)
        {
            var phone = _dbContext.Phones.FirstOrDefault(x => x.Id == id);
            if (phone is null)
                throw new NotFoundException("Phone not found");
            var result = _mapper.Map<PhoneDto>(phone);
            return result;

        }
        public void UpdatePhone(int id, UpdatePhoneDto dto)
        {
            var phone = _dbContext
                   .Phones
                   .FirstOrDefault(r => r.Id == id);

            if (phone is null)
                throw new NotFoundException("Phone not found");

            phone.Description = dto.Description;
            phone.Price = dto.Price;
            _dbContext.SaveChanges();

        }
        public void PatchUpdatePhone(int id, JsonPatchDocument phoneUpdateDto)
        {
            var phone = _dbContext.Phones.FirstOrDefault(x=>x.Id == id);

            if (phone is null)
                throw new NotFoundException("Phone not found");

                phoneUpdateDto.ApplyTo(phone);
                _dbContext.SaveChanges();
            
        }
    }
}
      