namespace StudentTeacherMtoNAPI.Models
{
    public class Teacher
    {
        public required Guid TeacherId { get; set; }
        public required string TeacherName { get; set; } = string.Empty;
        public required ICollection<Lesson> TeacherLessons { get; set; }
    }
}
