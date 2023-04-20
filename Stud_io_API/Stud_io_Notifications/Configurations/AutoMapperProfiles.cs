using AutoMapper;
using Stud_io_Notifications.Models;
using Stud_io_Notifications.DTOs;

namespace Stud_io_Notifications.Configurations
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
