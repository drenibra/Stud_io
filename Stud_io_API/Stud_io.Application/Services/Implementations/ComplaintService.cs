using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;
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
            if(complaint == null)
            {
                return new NotFoundObjectResult("Complaint does not exist");
            }

            var complaintDto = new ComplaintDto()
            {
                Description = complaint.Description
            };

            var httpClient = _httpClientFactory.CreateClient();

            var uri = "http://localhost:5274/api/v1/User/get-complaint-students";

            var adminToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5MDI0ZmFhYy0zZDIyLTQ3MmUtYTljZC0yYjVhMTk0OTZmODEiLCJ1bmlxdWVfbmFtZSI6ImFsbWEiLCJlbWFpbCI6ImFuNTE3MThAdWJ0LXVuaS5uZXQiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2ODcxMzkyNzQsImV4cCI6MTY4Nzc0NDA3NCwiaWF0IjoxNjg3MTM5Mjc0fQ.KfkZmwdpArgaKIhgoUvzLkiFjNqZusNiT4em87SkSnY";

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            var response = await httpClient.GetAsync(uri);

            var responseAsString = await response.Content.ReadAsStringAsync();

            var studentApi = JsonSerializer.Deserialize<StudentDeserializer>(responseAsString);


            // qetu kom met

            //var mappedComplaint = _mapper.Map<ComplaintDto>(await _context.Complaints.FindAsync(id));
            //return mappedComplaint == null
            //    ? new NotFoundObjectResult("Complaint doesn't exist!!")
            //    : new OkObjectResult(mappedComplaint);
        }
        

        public async Task<ActionResult> AddComplaint(ComplaintDto complaintDto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            if (complaintDto == null)
                return new BadRequestObjectResult("Complaint can not be null!!");
            var mappedFaculty = _mapper.Map<Complaint>(complaintDto);
            await _context.Complaints.AddAsync(mappedFaculty);
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
                return new NotFoundObjectResult("Comllaint doesn't exist!!");

            _context.Complaints.Remove(dbComplaint);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Complaint deleted successfully!");
        }
    }
}

