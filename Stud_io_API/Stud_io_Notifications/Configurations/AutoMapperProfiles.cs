using AutoMapper;
using Stud_io.Models;
using Stud_io.DTOs;

namespace Stud_io_Dormitory.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Announcement, AnnouncementDTO>().ReverseMap();
            CreateMap<Deadline, DeadlineDTO>().ReverseMap();
            CreateMap<Information, InformationDTO>().ReverseMap();
        }
    }
}
