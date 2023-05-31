using AutoMapper;
using Stud_io.DTOs;
using Stud_io.StudyGroups.Models;

namespace Stud_io.StudyGroups.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();
        }
    }
}
