using AutoMapper;
using Stud_io_Dormitory.DTOs;
using Stud_io_Dormitory.Models;

namespace Stud_io_Dormitory.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Dormitory, DormitoryDto>().ReverseMap();
        }
    }
}
