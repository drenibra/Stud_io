using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Maintenance.Configurations;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Models;
using Stud_io.Maintenance.Paging;
using Stud_io.Maintenance.Service.Interfaces;

namespace Stud_io.Maintenance.Service.Implementation
{
    public class DormComplaintService : IDormComplaintService
    {
        private readonly MaintenanceDbContext _context;
        private readonly IMapper _mapper;

        public DormComplaintService(MaintenanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<GetDormComplaintDto>> GetDormComplaintById(int id)
        {
            var complaint = _mapper.Map<GetDormComplaintDto>(await _context.DormComplaints.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync());

            if (complaint is null)
                return new NotFoundObjectResult("Complaint not found or has been deleted.");

            return new OkObjectResult(complaint);
        }

        //TODO: return a tuple -> the list and its count so we know how many records are total.
        public async Task<ActionResult<List<GetDormComplaintDto>>> GetDormComplaints(FilterDormComplaintDto filter, int? pageNumber)
        {
            var complaints = _context.DormComplaints
                                    .Where(x => !x.IsDeleted
                                            && x.StudentId == (filter.StudentId ?? x.StudentId)
                                            && x.DormNo == (filter.DormNo ?? x.DormNo)
                                            && x.Type.Equals(filter.Type ?? x.Type)
                                            && x.IsResolved == (filter.IsResolved ?? x.IsResolved))
                                    .OrderByDescending(x => x.DateCreated)
                                    .AsQueryable();

            var dtoComplaints = _mapper.Map<List<GetDormComplaintDto>>(await PaginatedList<DormComplaint>.Create(complaints, pageNumber ?? 1, 10));

            if (!dtoComplaints.Any())
                return new NotFoundObjectResult("No data with these parameters was found.");

            return new OkObjectResult(dtoComplaints);
        }

        public async Task<ActionResult> CreateDormComplaint(CreateDormComplaintDto dto)
        {
            var complaint = new DormComplaint()
            {
                StudentId = dto.StudentId,
                DormNo = dto.DormNo,
                Title = dto.Title,
                Description = dto.Description,
                FloorNo = dto.FloorNo,
                Type = dto.Type,
                DateCreated = dto.DateCreated,
            };

            await _context.DormComplaints.AddAsync(complaint);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dorm complaint added succesfully.");
        }
        public async Task<ActionResult> UpdateDormComplaint(int id, UpdateDormComplaintDto dto)
        {
            var dbComplaint = await _context.DormComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Dorm complaint with this id doesn't exist.");

            dbComplaint.StudentId = dto.StudentId;
            dbComplaint.DormNo = dto.DormNo;
            dbComplaint.Title = dto.Title;
            dbComplaint.Description = dto.Description;
            dbComplaint.FloorNo = dto.FloorNo;
            dbComplaint.Type = dto.Type;
            dbComplaint.IsResolved = dto.IsResolved;

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new OkObjectResult("Dorm complaint updated succesfully.");
            else
                return new BadRequestObjectResult("Something went wrong.");
        }

        public async Task<ActionResult> DeleteDormComplaint(int id)
        {
            var dbComplaint = await _context.DormComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Dorm complaint with this id doesn't exist.");

            dbComplaint.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dorm complaint deleted succesfully.");
        }
        public async Task<ActionResult> ResolveDormComplaint(int id, bool status)
        {
            var dbComplaint = await _context.DormComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Dorm complaint with this id doesn't exist.");

            dbComplaint.IsResolved = status;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dorm complaint's status updated succesfully.");
        }

    }
}
