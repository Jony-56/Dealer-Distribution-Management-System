using AutoMapper;
using DDMS.Application.Features.Brands.DTOs;
using DDMS.Domian.Entities;

namespace DDMS.Application.Common.Mappings;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandResponse>();

        CreateMap<CreateBrandRequest, Brand>();

        CreateMap<UpdateBrandRequest, Brand>();
    }
}