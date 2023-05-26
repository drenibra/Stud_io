using AutoMapper;
using Stud_io.Payment.DTOs;
using Stud_io.Payment.Models;

namespace Stud_io_Payment.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TypeOfPayment, TypeOfPaymentDto>().ReverseMap();
        }
    }
}
