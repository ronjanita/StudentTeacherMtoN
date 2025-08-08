using StudentTeacherMtoNAPI.Interface;
using Microsoft.EntityFrameworkCore;
using StudentTeacherMtoNAPI.Models;
using StudentTeacherMtoNAPI.Data;
using StudentTeacherMtoNAPI.DTO;
using StudentTeacherMtoNAPI.DTO.Student;

namespace StudentTeacherMtoNAPI.Repository
{
    public class StudentRepository(DataContext context) : IStudentRepository
    {
        private readonly DataContext _context = context;
        public async Task<ICollection<Student>> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }
        public async Task<Student> AddStudent(Student newStudent)
        {
            await _context.Students.AddAsync(newStudent);
            await SaveChangesAsync();
            return newStudent;
        }
        public async Task<Student> GetStudentById(Guid Id)
        {
            Student student = await _context.Students.FindAsync(Id);
            return student;
        }
        async public Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

       async public Task<Student> UpdateStudent(StudentDTO updatedStudentInfo, Guid Id)
        {
            var student = await _context.Students.FindAsync(Id);
            student.StudentName = updatedStudentInfo.StudentName;
            await SaveChangesAsync();
            return student;
        }
    }
}
