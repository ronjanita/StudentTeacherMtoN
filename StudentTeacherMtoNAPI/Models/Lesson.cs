using System.ComponentModel.DataAnnotations;

namespace StudentTeacherMtoNAPI.Models
{
    public class Lesson
    {
        [Key] public required Guid LessonId { get; set; }
        public required string LessonName { get; set; } = string.Empty;
        public required ICollection<Enrollement> Enrollements { get; set; }
        public required ICollection<Assignement> Assignements { get; set; }
        public required Guid RoomId { get; set; }
    }
}
