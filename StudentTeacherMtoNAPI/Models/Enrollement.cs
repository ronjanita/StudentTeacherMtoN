namespace StudentTeacherMtoNAPI.Models
{
    public class Enrollement
    {
        public required Guid StudentId { get; set; }
        public required Student Student { get; set; }
        public required Guid LessonId { get; set; }
        public required Lesson Lesson { get; set; }
    }
}
