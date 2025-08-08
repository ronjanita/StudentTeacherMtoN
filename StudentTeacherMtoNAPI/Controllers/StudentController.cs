using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;
using AutoMapper;

namespace StudentTeacherMtoNAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentTeacherRepository studentTeacherRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentTeacherRepository _StudentTeacherRepository = studentTeacherRepository;
        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> GetAllStudents()
        {
            ICollection<Student> students = await _StudentTeacherRepository.GetAllStudents();
            List<StudentDTO> studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }
    }
}
