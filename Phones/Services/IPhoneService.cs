using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models;

namespace Phones.Services;

public interface IPhoneService
{
    ActionResult<IEnumerable<PhoneDto>> GetAll();
    public int CreatePhone(CreatePhoneDto dto);
}