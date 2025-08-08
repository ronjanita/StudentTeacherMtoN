using Microsoft.EntityFrameworkCore;
using StudentTeacherMtoNAPI.Data;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.DTO.Teacher;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Repository
{
    public class TeacherRepository(DataContext context) : ITeacherRepository
    {
        private readonly DataContext _context = context;
        public async Task<ICollection<Teacher>> GetAllTeachers()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return teachers;
        }
        public async Task<Teacher> AddTeacher(Teacher newTeacher)
        {
            await _context.Teachers.AddAsync(newTeacher);
            await SaveChangesAsync();
            return newTeacher;
        }
        public async Task<Teacher> GetTeacherById(Guid Id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(Id);
            return teacher;
        }

        async public Task<Teacher> UpdateTeacher(TeacherDTO updatedTeacherInfo, Guid Id)
        {
            var teacher = await _context.Teachers.FindAsync(Id);
            teacher.TeacherName = updatedTeacherInfo.TeacherName;
            await SaveChangesAsync();
            return teacher;
        }
        async public Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
