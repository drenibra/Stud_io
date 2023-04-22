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
        }
    }
}
