using Microsoft.AspNetCore.Mvc;
using Phones.Entities;

namespace Phones.Services;

public interface IPhoneService
{
    ActionResult<IEnumerable<Phone>> GetAll();
}