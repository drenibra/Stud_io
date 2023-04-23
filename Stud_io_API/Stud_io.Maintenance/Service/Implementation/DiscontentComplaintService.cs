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
    public class DiscontentComplaintService : IDiscontentComplaintService
    {
        private readonly MaintenanceDbContext _context;
        private readonly IMapper _mapper;

        public DiscontentComplaintService(MaintenanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<GetDiscontentComplaintDto>> GetDiscontentComplaintById(int id)
        {
            var complaint = _mapper.Map<GetDiscontentComplaintDto>(await _context.DiscontentComplaints.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync());

            if (complaint is null)
                return new NotFoundObjectResult("Complaint not found or has been deleted.");

            return new OkObjectResult(complaint);
        }

        //TODO: return a tuple -> the list and its count so we know how many records are total.
        public async Task<ActionResult<List<GetDiscontentComplaintDto>>> GetDiscontentComplaints(FilterDiscontentComplaintDto filter, int? pageNumber)
        {
            var complaints = _context.DiscontentComplaints
                                    .Where(x => !x.IsDeleted
                                            && x.StudentId == (filter.StudentId ?? x.StudentId)
                                            && x.DormNo == (filter.DormNo ?? x.DormNo)
                                            && x.ApplicationId == (filter.ApplicationId ?? x.ApplicationId)
                                            && x.IsResolved == (filter.IsResolved ?? x.IsResolved))
                                    .OrderByDescending(x => x.DateCreated)
                                    .AsQueryable();

            var dtoComplaints = _mapper.Map<List<GetDiscontentComplaintDto>>(await PaginatedList<DiscontentComplaint>.Create(complaints, pageNumber ?? 1, 10));

            if (!dtoComplaints.Any())
                return new NotFoundObjectResult("No data with these parameters was found.");

            return new OkObjectResult(dtoComplaints);
        }

        public async Task<ActionResult> CreateDiscontentComplaint(CreateDiscontentComplaintDto dto)
        {
            var complaint = new DiscontentComplaint()
            {
                StudentId = dto.StudentId,
                DormNo = dto.DormNo,
                Title = dto.Title,
                Description = dto.Description,
                ApplicationId = dto.ApplicationId,
                DateCreated = dto.DateCreated,
            };
            //TODO: Send notification to student that was complained againts

            await _context.DiscontentComplaints.AddAsync(complaint);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Discontent complaint added succesfully.");
        }
        public async Task<ActionResult> UpdateDiscontentComplaint(int id, UpdateDiscontentComplaintDto dto)
        {
            var dbComplaint = await _context.DiscontentComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Discontent complaint with this id doesn't exist.");

            dbComplaint.StudentId = dto.StudentId;
            dbComplaint.DormNo = dto.DormNo;
            dbComplaint.Title = dto.Title;
            dbComplaint.Description = dto.Description;
            dbComplaint.ApplicationId = dto.ApplicationId;
            dbComplaint.IsResolved = dto.IsResolved;

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new OkObjectResult("Discontent complaint updated succesfully.");
            else
                return new BadRequestObjectResult("Something went wrong.");
        }

        public async Task<ActionResult> DeleteDiscontentComplaint(int id)
        {
            var dbComplaint = await _context.DiscontentComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Discontent complaint with this id doesn't exist.");

            dbComplaint.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Discontent complaint deleted succesfully.");
        }
        public async Task<ActionResult> ResolveDiscontentComplaint(int id, bool status)
        {
            var dbComplaint = await _context.DiscontentComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Discontent complaint with this id doesn't exist.");

            dbComplaint.IsResolved = status;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Discontent complaint's status updated succesfully.");
        }
    }
}
