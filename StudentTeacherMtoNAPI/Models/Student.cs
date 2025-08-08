using System.ComponentModel.DataAnnotations;

namespace StudentTeacherMtoNAPI.Models;

public class Student
{
    [Key] public required Guid StudentId { get; set; }
    public required string StudentName { get; set; } = string.Empty;
    public required ICollection<Enrollement> Enrollements { get; set; } 
}
