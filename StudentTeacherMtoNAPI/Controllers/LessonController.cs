using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherMtoNAPI.DTO.Lesson;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController(ILessonRepository LessonRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILessonRepository _LessonRepository = LessonRepository;
        [HttpGet]
        public async Task<ActionResult<List<LessonDTO>>> GetAllLessons()
        {
            ICollection<Lesson> lessons = await _LessonRepository.GetAllLessons();
            List<LessonDTO> lessonDTOs = _mapper.Map<List<LessonDTO>>(lessons);
            return Ok(lessonDTOs);
        }
        [HttpPost]
        public async Task<ActionResult<LessonDTO>> AddLesson([FromBody] LessonAddDTO lesson)
        {

            Lesson mappedLesson = _mapper.Map<Lesson>(lesson);
            Lesson createdLesson = await _LessonRepository.AddLesson(mappedLesson);
            return Ok(createdLesson);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDTO>> GetLessonById(Guid Id)
        {
            Lesson lesson = await _LessonRepository.GetLessonById(Id);
            LessonDTO mappedLesson = _mapper.Map<LessonDTO>(lesson);
            return Ok(mappedLesson);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Lesson>> UpdateLesson(Guid Id, [FromBody] LessonDTO updatedLessonInfo)
        {
            Lesson updatedLesson = await _LessonRepository.UpdateLesson(updatedLessonInfo, Id);
            return Ok(updatedLesson);
        }

    }
}
