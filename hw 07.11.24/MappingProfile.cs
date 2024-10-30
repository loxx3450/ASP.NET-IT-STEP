using AutoMapper;
using hw_07._11._24.DTOs;
using hw_07._11._24.Models;

namespace hw_07._11._24
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, DriverDTO>().ReverseMap();
        }
    }
}
