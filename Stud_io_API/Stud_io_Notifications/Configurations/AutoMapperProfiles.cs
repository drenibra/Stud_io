using AutoMapper;
using Notifications.Models;
using Stud_io_Notifications.DTOs;

namespace Stud_io_Notifications.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            CreateMap<Deadline, DeadlineDto>().ReverseMap();
            CreateMap<Information, InformationDto>().ReverseMap();
        }
    }
}