using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StudentTeacherMtoNAPI.DTO.Teacher;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;
using StudentTeacherMtoNAPI.Repository;

namespace StudentTeacherMtoNAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ITeacherRepository TeacherRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ITeacherRepository _TeacherRepository = TeacherRepository;
        [HttpGet]
        public async Task<ActionResult<List<TeacherDTO>>> GetAllTeachers()
        {
            ICollection<Teacher> teachers = await _TeacherRepository.GetAllTeachers();
            List<TeacherDTO> studentDTOs = _mapper.Map<List<TeacherDTO>>(teachers);
            return Ok(studentDTOs);
        }
        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> AddTeacher([FromBody] TeacherAddDTO teacher)
        {

            Teacher mappedTeacher = _mapper.Map<Teacher>(teacher);
            Teacher createdTeacher = await _TeacherRepository.AddTeacher(mappedTeacher);
            return Ok(createdTeacher);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacherById(Guid Id)
        {
            Teacher teacher = await _TeacherRepository.GetTeacherById(Id);
            TeacherDTO mappedTeacher = _mapper.Map<TeacherDTO>(teacher);
            return Ok(mappedTeacher);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> UpdateTeacher(Guid Id, [FromBody] TeacherDTO updatedTeacherInfo)
        {
            Teacher updatedTeacher = await _TeacherRepository.UpdateTeacher(updatedTeacherInfo, Id);
            return Ok(updatedTeacher);
        }
    }
}
