using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.DTO.Teacher;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Interface
{
    public interface ITeacherRepository
    {
        Task<ICollection<Teacher>> GetAllTeachers();
        Task<Teacher> AddTeacher(Teacher newTeacher);
        Task<Teacher> GetTeacherById(Guid Id);
        Task<Teacher> UpdateTeacher(TeacherDTO updatedTeacherInfo, Guid Id);
    }
}
