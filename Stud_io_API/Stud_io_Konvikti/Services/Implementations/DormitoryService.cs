using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stud_io.Dormitory.Models;
using Stud_io_Dormitory.Configurations;
using Stud_io_Dormitory.DTOs;
using Stud_io_Dormitory.Models;
using Stud_io_Dormitory.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace Stud_io_Dormitory.Services.Implementations
{
    public class DormitoryService : IDormitoryService
    {
        private readonly DormitoryDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public DormitoryService(DormitoryDbContext context, IMapper mapper , IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<List<DormitoryDto>>> GetDormitories() =>
            _mapper.Map<List<DormitoryDto>>(await _context.Dormitories.ToListAsync());

        public async Task<ActionResult<DormitoryDto>> GetDormitoryById(int id)
        {
            var mappedDormitory = _mapper.Map<DormitoryDto>(await _context.Dormitories.FindAsync(id));
            return mappedDormitory == null
                ? new NotFoundObjectResult("Dormitory doesn't exist!!")
                : new OkObjectResult(mappedDormitory);
        }

        public async Task<ActionResult> AddDormitory(DormitoryDto dormitoryDTO)
        {
            if (dormitoryDTO == null)
                return new BadRequestObjectResult("Dormitory can not be null!!");
            var mappedDormitory = _mapper.Map<Dormitory>(dormitoryDTO);
            await _context.Dormitories.AddAsync(mappedDormitory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dormitory added successfully!");
        }

        public async Task<ActionResult> UpdateDormitory(int id, UpdateDormitoryDto updateDormitoryDTO)
        {
            if (updateDormitoryDTO == null)
                return new BadRequestObjectResult("Dormitory can not be null!!");

            var dbDormitory = await _context.Dormitories.FindAsync(id);
            if (dbDormitory == null)
                return new NotFoundObjectResult("Dormitory doesn't exist!!");

            dbDormitory.DormNo = updateDormitoryDTO.DormNo ?? dbDormitory.DormNo;
            dbDormitory.Gender = updateDormitoryDTO.Gender ?? dbDormitory.Gender;
            dbDormitory.NoOfRooms = updateDormitoryDTO.NoOfRooms ?? dbDormitory.NoOfRooms;
            dbDormitory.Capacity = updateDormitoryDTO.Capacity ?? dbDormitory.Capacity;
      
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dormitory updated successfully!");
        }

        public async Task<ActionResult> DeleteDormitory(int id)
        {
            var dbDormitory = await _context.Dormitories.FindAsync(id);
            if (dbDormitory == null)
                return new NotFoundObjectResult("Dormitory doesn't exist!!");

            _context.Dormitories.Remove(dbDormitory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dormitory deleted successfully!");
        }

        public async Task AssignStudentsToDormitories()
        {

            var httpClient = _httpClientFactory.CreateClient();

            var uri = "http://localhost:5274/api/v1/User/GetStudents";
            
            // Get the admin token from your authentication mechanism
            var adminToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJjMGQwY2RjNC1kYTg1LTQ1NDAtYWNkZi1lMjlmNjQ2YWMwNzkiLCJ1bmlxdWVfbmFtZSI6ImJsZW9uYSIsImVtYWlsIjoiYmc1MjczMkB1YnQtdW5pLm5ldCIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTY4NzA2MTk5MywiZXhwIjoxNjg3NjY2NzkzLCJpYXQiOjE2ODcwNjE5OTN9.e0EX3Xrosr_PVjCxOcb17Z0cRU9_Xa2zHWLeU3d5D7A";

            // Set the admin token in the request headers
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            var response = await httpClient.GetAsync(uri);


            if (response.IsSuccessStatusCode)
            {
                var studentsJson = await response.Content.ReadAsStringAsync();

                var students = JsonConvert.DeserializeObject<List<Student>>(studentsJson);

                var acceptedStudents = students.Where(s => s.isAccepted).ToList();
                var femaleStudents = acceptedStudents.Where(s => s.Gender == 'F').ToList();
                var maleStudents = acceptedStudents.Where(s => s.Gender == 'M').ToList();

                await AssignStudentsToDormitory(femaleStudents, 'F');
                await AssignStudentsToDormitory(maleStudents, 'M');

                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case when the API request was not successful
                // You can log an error or take appropriate action
            }
        }

        private async Task AssignStudentsToDormitory(List<Student> students, char gender)
        {
            var dormitories = await _context.Dormitories
                .Where(d => d.Gender == gender && d.CurrentStudents < d.Capacity)
                .ToListAsync();

            foreach (var student in students.Where(s => !s.DormNumber.HasValue))
            {
                var dormitory = dormitories.FirstOrDefault();

                if (dormitory != null)
                {
                    student.DormNumber = dormitory.DormNo;
                    dormitory.CurrentStudents++;
                }
                else
                {
                    break;
                }
            }
        }


        /*  public async Task AssignStudentsToDormitories()
          {
              var httpClient = _httpClientFactory.CreateClient();



              var acceptedStudents = await _context.Students.Where(s => s.isAccepted).ToListAsync();
              var femaleStudents = acceptedStudents.Where(s => s.Gender == 'F').ToList();
              var maleStudents = acceptedStudents.Where(s => s.Gender == 'M').ToList();

              await AssignStudentsToDormitory(femaleStudents, 'F');
              await AssignStudentsToDormitory(maleStudents, 'M');

              await _context.SaveChangesAsync();
          }

          private async Task AssignStudentsToDormitory(List<Student> students, char gender)
          {
              var dormitories = await _context.Dormitories
                  .Where(d => d.Gender == gender && d.CurrentStudents < d.Capacity)
                  .ToListAsync();

              foreach (var student in students.Where(s => !s.DormNumber.HasValue))
              {
                  var dormitory = dormitories.FirstOrDefault();

                  if (dormitory != null)
                  {
                      student.DormNumber = dormitory.DormNo;
                      dormitory.CurrentStudents++;
                  }
                  else
                  {
                      break;
                  }
              }
          }
        */

    }

}


