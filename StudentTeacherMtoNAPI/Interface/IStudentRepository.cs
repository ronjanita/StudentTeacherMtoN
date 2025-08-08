using StudentTeacherMtoNAPI.Models;
using StudentTeacherMtoNAPI.DTO;
using StudentTeacherMtoNAPI.DTO.Student;

namespace StudentTeacherMtoNAPI.Interface

{
    public interface IStudentRepository 
    {
        Task<ICollection<Student>> GetAllStudents();
        Task<Student> AddStudent(Student newStudent);
        Task<Student> GetStudentById(Guid Id);
        Task<Student> UpdateStudent(StudentDTO updatedStudentInfo, Guid Id);
    }
}
