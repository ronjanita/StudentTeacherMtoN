using AutoMapper;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentAddDTO>().ReverseMap();
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();
        }
    }
}
