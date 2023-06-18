using AutoMapper;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;

namespace Stud_io.Application.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<ApplicationForm, ApplicationDto>().ReverseMap();
            CreateMap<ProfileMatch, ProfileMatchDto>().ReverseMap();
            CreateMap<Complaint, ComplaintDto>().ReverseMap();
        }
    }
}
