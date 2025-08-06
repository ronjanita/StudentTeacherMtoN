namespace StudentTeacherMtoNAPI.Models;

public class Student
{
    public required Guid StudentId { get; set; }
    public required string StudentName { get; set; } = string.Empty;
    public required ICollection<Lesson> StudentLessons { get; set; } 
}
