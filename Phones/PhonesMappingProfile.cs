using AutoMapper;
using Phones.Entities;
using Phones.Models.BrandModel;
using Phones.Models.PhoneModel;

namespace Phones;

public class PhonesMappingProfile :Profile
{
    public PhonesMappingProfile()
    {
        CreateMap<Phone, PhoneDto>()
            .ForMember(m => m.BrandName, n => n.MapFrom(b => b.Brand.Name));
        CreateMap<Brand, BrandDto>();

        CreateMap<CreatePhoneDto, Phone>();
        CreateMap<CreateBrandDto, Brand>();
    }     
}
