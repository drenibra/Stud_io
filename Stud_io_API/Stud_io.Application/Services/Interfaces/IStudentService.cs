using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<ActionResult<List<StudentDto>>> GetStudents();
        public Task<ActionResult<StudentDto>> GetStudentById(int id);
        public Task<ActionResult> AddStudent(StudentDto studentDTO);
        public Task<ActionResult> UpdateStudent(int id, UpdateStudentDto updateStudentDTO);
        public Task<ActionResult> DeleteStudent(int id);
   
    }
}
