using AutoMapper;
using DriversManagement.API.DTOs;
using DriversManagement.API.Models;
using hw_07._11._24_DriverManagement_.DTOs;

namespace DriversManagement.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Driver, DriverDTO>()
            .ForMember(
                x => x.CategoryId,
                cnf => cnf.MapFrom(x => x.Category.Id))
            .ReverseMap();

        CreateMap<Vehicle, VehicleDTO>()
            .ForMember(
                x => x.DriverId,
                cnf => cnf.MapFrom(x => x.Driver.Id))
            .ReverseMap();
    }
}
