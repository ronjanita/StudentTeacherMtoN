namespace StudentTeacherMtoNAPI.Models
{
    public class Lesson
    {
        public required Guid LessonId { get; set; }
        public required string LessonName { get; set; } = string.Empty;
        public required ICollection<Student> StudentsOfLesson { get; set; } 
        public required ICollection<Teacher> TeachersOfLesson { get; set; } 
        public required Room RoomOfLesson { get; set; }
    }
}
