using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;
using Stud_io.Authentication.DTOs;
using Stud_io.Authentication.Models;

namespace Stud_io.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<StudentDto>>> GetStudents() =>
            _mapper.Map<List<StudentDto>>(await _context.Students.ToListAsync());

        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var mappedStudent = _mapper.Map<StudentDto>(await _context.Students.FindAsync(id));
            return mappedStudent == null
                ? new NotFoundObjectResult("Student doesn't exist!!")
                : new OkObjectResult(mappedStudent);
        }

        public async Task<ActionResult<StudentDto>> GetStudentByPersonalNo(string personalNo)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.PersonalNo == personalNo);
            var mappedStudent = _mapper.Map<StudentDto>(student);

            return student == null
                ? new NotFoundObjectResult("Student doesn't exist!")
                : new OkObjectResult(mappedStudent);
        }


        public async Task<ActionResult> AddStudent(StudentDto studentDTO)
        {
            if (studentDTO == null)
                return new BadRequestObjectResult("Student can not be null!!");
            var mappedStudent = _mapper.Map<Student>(studentDTO);
            await _context.Students.AddAsync(mappedStudent);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Student added successfully!");
        }
        
        //public async Task<ActionResult> UpdateStudent(int id, UpdateStudentDto updateStudentDTO)
        //{
        //    if (updateStudentDTO == null)
        //        return new BadRequestObjectResult("Student can not be null!!");

        //    var dbStudent = await _context.Students.FindAsync(id);
        //    if (dbStudent == null)
        //        return new NotFoundObjectResult("Student doesn't exist!!");

        //    dbStudent.PersonalNo = updateStudentDTO.PersonalNo ?? dbStudent.PersonalNo;
        //    dbStudent.Name = updateStudentDTO.Name ?? dbStudent.Name;
        //    dbStudent.ParentName = updateStudentDTO.ParentName ?? dbStudent.ParentName;
        //    dbStudent.Surname = updateStudentDTO.Surname ?? dbStudent.Surname;
        //    dbStudent.City = updateStudentDTO.City ?? dbStudent.City;
        //    dbStudent.GPA = updateStudentDTO.GPA ?? dbStudent.GPA;
        //    dbStudent.PhoneNo = updateStudentDTO.PhoneNo ?? dbStudent.PhoneNo;
        //    dbStudent.Email = updateStudentDTO.Email ?? dbStudent.Email;
        //    dbStudent.Gender = updateStudentDTO.Gender ?? dbStudent.Gender;
        //    dbStudent.AcademicYear = updateStudentDTO.AcademicYear ?? dbStudent.AcademicYear;
        //    dbStudent.Status = updateStudentDTO.Status ?? dbStudent.Status;
        //    dbStudent.ProfilePicUrl = updateStudentDTO.ProfilePicUrl ?? dbStudent.ProfilePicUrl;
        //    dbStudent.FacultyId = updateStudentDTO.FacultyId ?? dbStudent.FacultyId;


        //    await _context.SaveChangesAsync();

        //    return new OkObjectResult("Student updated successfully!");
        //}

        public async Task<ActionResult> DeleteStudent(int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null)
                return new NotFoundObjectResult("Student doesn't exist!!");

            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Student deleted successfully!");
        }
    }
}
