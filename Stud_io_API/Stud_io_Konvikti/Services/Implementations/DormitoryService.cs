using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stud_io.Dormitory.DTOs.Deserializer;
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

        public DormitoryService(DormitoryDbContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
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

        public async Task AssignStudentsToDormitories(string token)
        {

            var httpClient = _httpClientFactory.CreateClient();

            var uri = "http://localhost:5274/api/v1/User/get-dormitory-students";  

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.GetAsync(uri);


            if (response.IsSuccessStatusCode)
            {
                var studentsJson = await response.Content.ReadAsStringAsync();

                var students = JsonConvert.DeserializeObject<List<StudentDeserializer>>(studentsJson);

                var acceptedStudents = students.Where(s => (bool)s.isAccepted).ToList();
                var femaleStudents = acceptedStudents.Where(s => s.Gender == 'F').ToList();
                var maleStudents = acceptedStudents.Where(s => s.Gender == 'M').ToList();

                await AssignStudentsToDormitory(femaleStudents, 'F', token);
                await AssignStudentsToDormitory(maleStudents, 'M', token);

                await _context.SaveChangesAsync();
            }
        }

        private async Task AddDormNumber(string studentId, int dormNo, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var uri = $"http://localhost:5274/api/v1/User/add-dorm-number/{studentId}/{dormNo}";

            //Dreni to handle the token
            var authentication = new AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var content = new StringContent("",Encoding.UTF8, "application/json");


            await httpClient.PutAsync(uri, content);
        }


        private async Task AssignStudentsToDormitory(List<StudentDeserializer> students, char gender, string token)
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
                    var id = student.Id;
                    await AddDormNumber(id, dormitory.DormNo, token);
                    dormitory.CurrentStudents++;
                }
                else
                {
                    break;
                }
            }
        }


    }

}

