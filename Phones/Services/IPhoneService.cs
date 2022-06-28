using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models;

namespace Phones.Services;

public interface IPhoneService
{
    ActionResult<IEnumerable<PhoneDto>> GetAll();
    PhoneDto GetById(int id);
    public int CreatePhone(CreatePhoneDto dto);
    void DeletePhone(int id);
    void UpdatePhone(int id, UpdatePhoneDto dto);

}