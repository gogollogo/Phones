using AutoMapper;
using Phones.Entities;
using Phones.Models;

namespace Phones;

public class PhonesMappingProfile :Profile
{
    public PhonesMappingProfile()
    {
        CreateMap<Phone, PhoneDto>()
            .ForMember(m => m.BrandName, n => n.MapFrom(b => b.Brand.Name));

        CreateMap<Brand, BrandDto>();

        CreateMap<CreatePhoneDto, Phone>();
    }     
}
