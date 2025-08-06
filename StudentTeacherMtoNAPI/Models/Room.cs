namespace StudentTeacherMtoNAPI.Models
{
    public class Room
    {
        public required Guid RoomId { get; set; }
        public required string RoomName { get; set; } = string.Empty;
        public required ICollection<Lesson> LessonInRoom { get; set; }
    }
}
