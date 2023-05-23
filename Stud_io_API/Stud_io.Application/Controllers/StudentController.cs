using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Controllers
{
    [Route("")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            return await _studentService.GetStudents();
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            return await _studentService.GetStudentById(id);
        }


        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddDormitory(StudentDto studentDto)
        {
            return await _studentService.AddStudent(studentDto);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent(int id, UpdateStudentDto studentDto)
        {
            return await _studentService.UpdateStudent(id, studentDto);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            return await _studentService.DeleteStudent(id);
        }
    }
}
