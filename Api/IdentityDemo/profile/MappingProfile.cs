using AutoMapper;
using IdentityDemo.DTOs;
using IdentityDemo.Model;

namespace IdentityDemo.profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDtoWithDetails>().ReverseMap();
            CreateMap<Brand, RegisterBrandDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<Car, RegisterCarDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarFilteredDto>().ReverseMap();
            CreateMap<Car, CarDtoWithDetails>().ReverseMap();
        }
    }
}
