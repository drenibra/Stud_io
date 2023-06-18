using AutoMapper;
using Stud_io.DTOs;
using Stud_io.Authentication.Models;
using Stud_io.Authentication.DTOs;
using Stud_io.Authentication.DTOs.ServiceCommunication.Dormitory;

namespace Stud_io.Authentication.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<AppUser, ProfileSpace.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}
