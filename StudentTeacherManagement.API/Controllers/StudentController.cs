using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherManagement.API.DTOs;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;

namespace StudentTeacherManagement.API.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddStudent([FromBody] CreateStudentDTO createStudentDTO)
        {
            var studentToAdd = _mapper.Map<Student>(createStudentDTO);
            studentToAdd.CreatedAt = DateTime.UtcNow;

            var student = await _studentService.AddStudent(studentToAdd);

            return Created($"students/{student.Id}", _mapper.Map<StudentDTO>(student));
        }
    }
}
