using AutoMapper;
using Payment.Models.Stripe;
using Stud_io.Payment.DTOs;
using Stud_io.Payment.Models;

namespace Stud_io_Payment.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TypeOfPayment, TypeOfPaymentDto>().ReverseMap();
            CreateMap<StripePayment, PaymentDto>().ReverseMap();
            CreateMap<StripeCustomer, CustomerDto>().ReverseMap();
        }
    }
}
