using AutoMapper;
using Notifications.Models;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;

namespace Stud_io_Notifications.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Deadline, DeadlineDto>().ReverseMap();
            //CreateMap<Information, InformationDTO>().ReverseMap();
        }
    }
}