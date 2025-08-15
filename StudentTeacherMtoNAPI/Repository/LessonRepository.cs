using Microsoft.EntityFrameworkCore;
using StudentTeacherMtoNAPI.Controllers;
using StudentTeacherMtoNAPI.Data;
using StudentTeacherMtoNAPI.DTO.Lesson;
using StudentTeacherMtoNAPI.DTO.Room;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;


namespace StudentTeacherMtoNAPI.Repository
{
    public class LessonRepository(DataContext context) : ILessonRepository
    {
        private readonly DataContext _context = context;
        public async Task<ICollection<Lesson>> GetAllLessons()
        {
            var lessons = await _context.Lessons.ToListAsync();
            return lessons;
        }
        public async Task<Lesson> AddLesson(Lesson newLesson)
        {
            await _context.Lessons.AddAsync(newLesson);
            await SaveChangesAsync();
            return newLesson;
        }
        public async Task<Lesson> GetLessonById(Guid Id)
        {
            Lesson lessons = await _context.Lessons.FindAsync(Id);
            return lessons;
        }

        async public Task<Lesson> UpdateLesson(LessonDTO updatedLessonInfo, Guid Id)
        {
            var lesson = await _context.Lessons.FindAsync(Id);
            lesson.LessonName = updatedLessonInfo.LessonName;
            await SaveChangesAsync();
            return lesson;
        }
        async public Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> AssignTeacherToLesson(Guid lessonId, Guid teacherId)
        {
            var lesson = await DbSet.FindAsync(lessonId);
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (lesson == null || teacher == null) return false;
            var newAssignement = new Assignement
            {
                Lesson = lesson,
                Teacher = teacher,
                LessonId = lessonId,
                TeacherId = teacherId

            };
            await _context.Assignements.AddAsync(newAssignement);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EnrollStudentToLesson(Guid lessonId, Guid studentId)
        {
            var lesson = await DbSet.FindAsync(lessonId);
            var student = await _context.Students.FindAsync(studentId);
            if (lesson == null || student == null) return false;
            var newEnrollement = new Enrollement
            {
                Lesson = lesson,
                Student = student,
                LessonId = lessonId,
                StudentId = studentId

            };
            await _context.Enrollements.AddAsync(newEnrollement);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
