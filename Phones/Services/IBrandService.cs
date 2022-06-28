using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models;

namespace Phones.Services;

public interface IBrandService
{
    ActionResult<IEnumerable<Brand>> GetAll();

    BrandDto GetById(int id);
    public int CreateBrand(CreateBrandDto dto);
    void DeleteBrand(int id);
    void UpdateBrand(int id, UpdateBrandDto dto);
}