using Microsoft.EntityFrameworkCore;
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
    }
}
