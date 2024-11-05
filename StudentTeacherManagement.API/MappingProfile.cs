using AutoMapper;
using StudentTeacherManagement.API.DTOs;
using StudentTeacherManagement.Core.Models;

namespace StudentTeacherManagement.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDTO>().ReverseMap();

            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
