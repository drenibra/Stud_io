using AutoMapper;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Models;

namespace Stud_io.Maintenance.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DTask, GetTaskDto>().ReverseMap();
            CreateMap<CreateTaskDto, DTask>().ReverseMap();
            CreateMap<DormComplaint, GetDormComplaintDto>().ReverseMap();
            CreateMap<CreateDormComplaintDto, DormComplaint>().ReverseMap();
            CreateMap<GetSocialComplaintDto, SocialComplaint>().ReverseMap();
            CreateMap<SocialComplaint, CreateSocialComplaintDto>().ReverseMap();
            CreateMap<GetDiscontentComplaintDto, DiscontentComplaint>().ReverseMap();
            CreateMap<DiscontentComplaint, CreateDiscontentComplaintDto>().ReverseMap();
        }
    }
}
