using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phones.Entities;
using Phones.Exceptions;
using Phones.Models.BrandModel;

namespace Phones.Services
{
    public class BrandService : IBrandService
    {
        private readonly PhonesDbContext _dbContext;
        private readonly IMapper _mapper;

        public BrandService(PhonesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int CreateBrand(CreateBrandDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);

            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();

            return brand.Id;
        }

        public void DeleteBrand(int id)
        {
            var brand = _dbContext
                 .Brands
                 .FirstOrDefault(r => r.Id == id);
            if (brand is null)
                throw new NotFoundException("Brand not found");
            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
        }

        public BrandDto GetById(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(x => x.Id == id);
            if (brand is null)
                throw new NotFoundException("Brand not found");
            var result = _mapper.Map<BrandDto>(brand);
            return result;
        }

        public void UpdateBrand(int id, UpdateBrandDto dto)
        {
            var brand = _dbContext
                  .Brands
                  .FirstOrDefault(r => r.Id == id);
            if (brand is null)
                throw new NotFoundException("Brand not found");
            brand.Name = dto.Name;
            
            _dbContext.SaveChanges();
        }

        ActionResult<IEnumerable<Brand>> IBrandService.GetAll()
        {
            var result = _dbContext.Brands.ToList();

            return result;
        }

       
    }
}
