using AutoMapper;
using Stud_io.DTOs;
using Stud_io.Authentication.Models;

namespace Stud_io.Authentication.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();
        }
    }
}
