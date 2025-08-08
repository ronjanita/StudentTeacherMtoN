using AutoMapper;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Models;
using StudentTeacherMtoNAPI.DTO.Teacher;
using StudentTeacherMtoNAPI.DTO.Room;

namespace StudentTeacherMtoNAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentAddDTO>().ReverseMap();
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();

            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, TeacherAddDTO>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDTO>().ReverseMap();

            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, RoomAddDTO>().ReverseMap();
            CreateMap<Room, RoomUpdateDTO>().ReverseMap();
        }
    }
}
