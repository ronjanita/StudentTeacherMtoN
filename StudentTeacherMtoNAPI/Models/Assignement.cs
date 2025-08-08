namespace StudentTeacherMtoNAPI.Models
{
    public class Assignement
    {
        public required Guid TeacherId { get; set; }
        public required Teacher Teacher { get; set; }
        public required Guid LessonId { get; set; }
        public required Lesson Lesson { get; set; }
    }
}
