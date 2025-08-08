using StudentTeacherMtoNAPI.DTO.Lesson;
using StudentTeacherMtoNAPI.DTO.Room;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Interface
{
    public interface ILessonRepository
    {
        Task<ICollection<Lesson>> GetAllLessons();
        Task<Lesson> AddLesson(Lesson newLesson);
        Task<Lesson> GetLessonById(Guid Id);
        Task<Lesson> UpdateLesson(LessonDTO updatedLessonInfo, Guid Id);
    }
}
