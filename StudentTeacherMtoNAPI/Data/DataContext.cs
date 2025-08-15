using Microsoft.EntityFrameworkCore;
using StudentTeacherMtoNAPI.Models;
namespace StudentTeacherMtoNAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Room> Rooms { get; set; } 
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Enrollement> Enrollements { get; set; }
    public DbSet<Assignement> Assignements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollement>()
        .HasKey(e => new { e.StudentId, e.LessonId });
        modelBuilder.Entity<Enrollement>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollements)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Enrollement>()
            .HasOne(e => e.Lesson)
            .WithMany(l => l.Enrollements)
            .HasForeignKey(e => e.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Assignement>()
            .HasKey(a => new { a.LessonId, a.TeacherId });
        modelBuilder.Entity<Assignement>()
            .HasOne(a => a.Lesson)
            .WithMany(l => l.Assignements)
            .HasForeignKey(a => a.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Assignement>()
            .HasOne(a => a.Teacher)
            .WithMany(t => t.Assignements)
            .HasForeignKey(a => a.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
