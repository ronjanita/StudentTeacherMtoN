using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherMtoNAPI.Interface;

namespace StudentTeacherMtoNAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AssignementController(ILessonRepository lessonRepository, IMapper mapper) : ControllerBase
{
    private readonly ILessonRepository _lessonRepository = lessonRepository;
    private readonly IMapper _mapper = mapper;
    [HttpPost("AddTeacherToLesson")]
    public async Task<ActionResult> AssignTeacherToLesson(Guid teacherId, Guid lessonId)
    {         var result = await _lessonRepository.AssignTeacherToLesson(teacherId, lessonId);
        if (result)
        {
            return Ok("Teacher added to course successfully.");
        }
        return BadRequest("Failed to add teacher to course.");
    }
}

