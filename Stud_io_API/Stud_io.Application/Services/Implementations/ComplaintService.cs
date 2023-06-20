using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;
using Stud_io.Application.Models.ServiceCommunication.Authentication;
using Stud_io.Application.DTOs.Deserializer;


namespace Stud_io.Application.Services.Implementations
{
    public class ComplaintService : IComplaintService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public ComplaintService(ApplicationDbContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<List<ComplaintDto>>> GetComplaints() =>
            _mapper.Map<List<ComplaintDto>>(await _context.Complaints.ToListAsync());


        public async Task<ActionResult<ComplaintDto>> GetComplaintById(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return new NotFoundObjectResult("Complaint does not exist");
            }

            var complaintDto = new ComplaintDto()
            {
                Description = complaint.Description,

            };

            var httpClient = _httpClientFactory.CreateClient();

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxZWIzMTJiMS01MzIyLTQ3M2ItYTFjOC02YmViMDg3OWU4ZDYiLCJ1bmlxdWVfbmFtZSI6ImFsbWEiLCJlbWFpbCI6ImFuNTE3MThAdWJ0LXVuaS5uZXQiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2ODcyMTk4MzMsImV4cCI6MTY4NzgyNDYzMywiaWF0IjoxNjg3MjE5ODMzfQ.3Cq2evwMGSBO6cIu53_X4RSIluYDm7RaO9ryLWpBm50");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var uri = "http://localhost:5274/api/v1/User/1eb312b1-5322-473b-a1c8-6beb0879e8d6";

            var response = await httpClient.GetAsync(uri);
            var responseAsString = await response.Content.ReadAsStringAsync();

            var studentApi = JsonSerializer.Deserialize<StudentComplaintDeserializer>(responseAsString);

            return new OkObjectResult(complaintDto);

        }


        public async Task<ActionResult> AddComplaint(ComplaintDto complaintDto)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var uri = "http://localhost:5274/api/v1/User/GetStudentById";

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI3NzgzNGMxMC0wMjRlLTQwNmMtODU2Ny03NGQzZGMwYTM1NmYiLCJ1bmlxdWVfbmFtZSI6Im1hbGlzYSIsImVtYWlsIjoibXNhZGlrdUBnbWFpbC5jb20iLCJyb2xlIjoiU3R1ZGVudCIsIm5iZiI6MTY4NzIxODY2MCwiZXhwIjoxNjg3ODIzNDYwLCJpYXQiOjE2ODcyMTg2NjB9.Jz8e7luLq5Gf5JqAkhHfoVpDRtU5FGEhRJqpif3J0V8");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var response = await httpClient.GetAsync(uri);

            var responseAsString = await response.Content.ReadAsStringAsync();

            var student = JsonSerializer.Deserialize<StudentComplaintDeserializer>(responseAsString);

            var complaint = new Complaint()
            {

                Description = complaintDto.Description,
                StudentsId = student.id,

            };

            await _context.Complaints.AddAsync(complaint);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Complaint added successfully!");
        }

        public async Task<ActionResult> UpdateComplaint(int id, UpdateComplaintDto updateComplaintDto)
        {
            if (updateComplaintDto == null)
                return new BadRequestObjectResult("Complaint can not be null!!");

            var dbComplaint = await _context.Complaints.FindAsync(id);
            if (dbComplaint == null)
                return new NotFoundObjectResult("Complaint doesn't exist!!");

            dbComplaint.Description = updateComplaintDto.Description ?? dbComplaint.Description;
            dbComplaint.StudentsId = updateComplaintDto.StudentsId ?? dbComplaint.StudentsId;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Complaint updated successfully!");
        }

        public async Task<ActionResult> DeleteComplaint(int id)
        {
            var dbComplaint = await _context.Complaints.FindAsync(id);
            if (dbComplaint == null)
                return new NotFoundObjectResult("Complaint doesn't exist!!");

            _context.Complaints.Remove(dbComplaint);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Complaint deleted successfully!");
        }
    }
}

