using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;
using AutoMapper;
using StudentTeacherMtoNAPI.Repository;

namespace StudentTeacherMtoNAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentRepository studentTeacherRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentRepository _StudentRepository = studentTeacherRepository;
        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> GetAllStudents()
        {
            ICollection<Student> students = await _StudentRepository.GetAllStudents();
            List<StudentDTO> studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> AddStudent([FromBody] StudentAddDTO student)
        {

            Student mappedStudent = _mapper.Map<Student>(student);
            Student createdStudent = await _StudentRepository.AddStudent(mappedStudent);
            return Ok(createdStudent);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(Guid Id)
        {
            Student student = await _StudentRepository.GetStudentById(Id);
            StudentDTO mappedStudent = _mapper.Map<StudentDTO>(student);
            return Ok(mappedStudent);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(Guid Id, [FromBody] StudentDTO updatedStudentInfo)
        {
            Student updatedStudent = await _StudentRepository.UpdateStudent(updatedStudentInfo, Id);
            return Ok(updatedStudent);
        }

    }
