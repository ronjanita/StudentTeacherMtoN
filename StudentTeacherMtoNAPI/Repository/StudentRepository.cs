using StudentTeacherMtoNAPI.Interface;
using Microsoft.EntityFrameworkCore;
using StudentTeacherMtoNAPI.Models;
using StudentTeacherMtoNAPI.Data;

namespace StudentTeacherMtoNAPI.Repository
{
    public class StudentTeacherRepository(DataContext context) : IStudentTeacherRepository
    {
        private readonly DataContext _context = context;
        public async Task<ICollection<Student>> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }
    }
}
