using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;

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
            var mappedComplaint = _mapper.Map<ComplaintDto>(await _context.Complaints.FindAsync(id));
            return mappedComplaint == null
                ? new NotFoundObjectResult("Complaint doesn't exist!!")
                : new OkObjectResult(mappedComplaint);
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

