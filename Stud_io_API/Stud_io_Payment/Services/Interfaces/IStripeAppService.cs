using Microsoft.AspNetCore.Mvc;
using Payment.Models.Stripe;
using Stud_io.Payment.DTOs;

namespace Payment.Contracts
{
    public interface IStripeAppService
    {
        Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
        Task<ActionResult<List<PaymentDto>>> GetPayments();
        Task<ActionResult<List<PaymentDto>>> GetPaymentsOfUser(string userId);
        Task<ActionResult<List<CustomerDto>>> GetCustomers();
    }
}