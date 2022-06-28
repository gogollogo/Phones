using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Phones.Entities;
using Phones.Models;
using Phones.Models.PhoneModel;

namespace Phones.Services;

public interface IPhoneService
{
    public PaginationData<PhoneDto> GetAll(PhoneQuery query);
    PhoneDto GetById(int id);
    public int CreatePhone(CreatePhoneDto dto);
    void DeletePhone(int id);
    void UpdatePhone(int id, UpdatePhoneDto dto);
    void PatchUpdatePhone(int id, JsonPatchDocument phoneUpdateDto);


}