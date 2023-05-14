using AutoMapper;
using Stud_io.Payment.DTOs;
using Stud_io.Payment.Models;
using Stud_io_Payment.DTOs;
using Stud_io_Payment.Models;

namespace Stud_io_Payment.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<History, HistoryDto>().ReverseMap();
            CreateMap<TypeOfPayment, TypeOfPaymentDto>().ReverseMap();
        }
    }
}
