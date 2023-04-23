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
    public class SocialComplaintService : ISocialComplaintService
    {
        private readonly MaintenanceDbContext _context;
        private readonly IMapper _mapper;

        public SocialComplaintService(MaintenanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<GetSocialComplaintDto>> GetSocialComplaintById(int id)
        {
            var complaint = _mapper.Map<GetSocialComplaintDto>(await _context.SocialComplaints.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync());

            if (complaint is null)
                return new NotFoundObjectResult("Complaint not found or has been deleted.");

            return new OkObjectResult(complaint);
        }

        //TODO: return a tuple -> the list and its count so we know how many records are total.
        public async Task<ActionResult<List<GetSocialComplaintDto>>> GetSocialComplaints(FilterSocialComplaintDto filter, int? pageNumber)
        {
            var complaints = _context.SocialComplaints
                                    .Where(x => !x.IsDeleted
                                            && x.StudentId == (filter.StudentId ?? x.StudentId)
                                            && x.DormNo == (filter.DormNo ?? x.DormNo)
                                            && x.ComplainedRoomNo.Equals(filter.ComplainedRoomNo ?? x.ComplainedRoomNo)
                                            && x.IsResolved == (filter.IsResolved ?? x.IsResolved))
                                    .OrderByDescending(x => x.DateCreated)
                                    .AsQueryable();

            var dtoComplaints = _mapper.Map<List<GetSocialComplaintDto>>(await PaginatedList<SocialComplaint>.Create(complaints, pageNumber ?? 1, 10));

            if (!dtoComplaints.Any())
                return new NotFoundObjectResult("No data with these parameters was found.");

            return new OkObjectResult(dtoComplaints);
        }

        public async Task<ActionResult> CreateSocialComplaint(CreateSocialComplaintDto dto)
        {
            var complaint = new SocialComplaint()
            {
                StudentId = dto.StudentId,
                DormNo = dto.DormNo,
                Title = dto.Title,
                Description = dto.Description,
                ComplainedRoomNo = dto.ComplainedRoomNo,
                DateCreated = dto.DateCreated,
            };
            //TODO: Send notification to student that was complained againts

            await _context.SocialComplaints.AddAsync(complaint);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Social complaint added succesfully.");
        }
        public async Task<ActionResult> UpdateSocialComplaint(int id, UpdateSocialComplaintDto dto)
        {
            var dbComplaint = await _context.SocialComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Social complaint with this id doesn't exist.");

            dbComplaint.StudentId = dto.StudentId;
            dbComplaint.DormNo = dto.DormNo;
            dbComplaint.Title = dto.Title;
            dbComplaint.Description = dto.Description;
            dbComplaint.ComplainedRoomNo = dto.ComplainedRoomNo;
            dbComplaint.IsResolved = dto.IsResolved;

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new OkObjectResult("Social complaint updated succesfully.");
            else
                return new BadRequestObjectResult("Something went wrong.");
        }

        public async Task<ActionResult> DeleteSocialComplaint(int id)
        {
            var dbComplaint = await _context.SocialComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Social complaint with this id doesn't exist.");

            dbComplaint.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Social complaint deleted succesfully.");
        }
        public async Task<ActionResult> ResolveSocialComplaint(int id, bool status)
        {
            var dbComplaint = await _context.SocialComplaints.FindAsync(id);

            if (dbComplaint == null)
                return new BadRequestObjectResult("Social complaint with this id doesn't exist.");

            dbComplaint.IsResolved = status;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Social complaint's status updated succesfully.");
        }

    }
}
