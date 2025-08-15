using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherMtoNAPI.Interface;

namespace StudentTeacherMtoNAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollementController(ILessonRepository lessonRepository, IMapper mapper) : ControllerBase
{
    private readonly ILessonRepository _lessonRepository = lessonRepository;
    private readonly IMapper _mapper = mapper;
    [HttpPost("AddStudentToLesson")]
    public async Task<ActionResult> EnrollStudentToLesson(Guid studentId, Guid lessonId)
    {
        var result = await _lessonRepository.EnrollStudentToLesson(studentId, lessonId);
        if (result)
        {
            return Ok("Student added to course successfully.");
        }
        return BadRequest("Failed to add student to course.");
    }
}
