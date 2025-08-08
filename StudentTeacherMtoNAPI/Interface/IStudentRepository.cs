using StudentTeacherMtoNAPI.Models;
using StudentTeacherMtoNAPI.DTO;

namespace StudentTeacherMtoNAPI.Interface

{
    public interface IStudentTeacherRepository 
    {
        Task<ICollection<Student>> GetAllStudents();
    }
}
