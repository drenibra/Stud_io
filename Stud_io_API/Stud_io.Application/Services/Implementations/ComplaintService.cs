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


        public Task<ActionResult<ComplaintDto>> GetComplaintById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<ComplaintDto>>> GetComplaints() =>
            _mapper.Map<List<ComplaintDto>>(await _context.Complaints.ToListAsync());

   
        //public async Task<ActionResult<ComplaintDetailsDto>> GetComplaintById(int id)
        //{
        //    var complaint = await _context.Complaints.FindAsync(id);
        //    if(complaint == null)
        //    {
        //        return new NotFoundObjectResult("Complaint does not exist");
        //    }

        //    var complaintDto = new ComplaintDetailsDto()
        //    {
        //        Description = complaint.Description,
        //        StudentsId = complaint.StudentsId
        //    };

        //    var httpClient = _httpClientFactory.CreateClient();

        //    var uri = "http://localhost:5274/api/v1/User/get-complaint-students/" + complaintDto.StudentsId;

        //    var adminToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5MDI0ZmFhYy0zZDIyLTQ3MmUtYTljZC0yYjVhMTk0OTZmODEiLCJ1bmlxdWVfbmFtZSI6ImFsbWEiLCJlbWFpbCI6ImFuNTE3MThAdWJ0LXVuaS5uZXQiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2ODcxMzkyNzQsImV4cCI6MTY4Nzc0NDA3NCwiaWF0IjoxNjg3MTM5Mjc0fQ.KfkZmwdpArgaKIhgoUvzLkiFjNqZusNiT4em87SkSnY";

        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

        //    var response = await httpClient.GetAsync(uri);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseAsString = await response.Content.ReadAsStringAsync();

        //        var studentApi = JsonConvert.DeserializeObject<List<StudentDeserializer>>(responseAsString);

        //    }




        //var mappedComplaint = _mapper.Map<ComplaintDto>(await _context.Complaints.FindAsync(id));
        //return mappedComplaint == null
        //    ? new NotFoundObjectResult("Complaint doesn't exist!!")
        //    : new OkObjectResult(mappedComplaint);
    //}
        

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

