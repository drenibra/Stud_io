using Microsoft.AspNetCore.Mvc;
using Payment.Contracts;
using Payment.Models.Stripe;
using Stud_io.Payment.DTOs;

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    public class StripeController : Controller
    {
        private readonly IStripeAppService _stripeService;

        public StripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer(
            [FromBody] AddStripeCustomer customer,
            CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(
                customer,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }

        [HttpPost("payment/add")]
        public async Task<ActionResult<StripePayment>> AddStripePayment(
            [FromBody] AddStripePayment payment,
            CancellationToken ct)
        {
            StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(
                payment,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdPayment);
        }

        [HttpGet("payments")]
        public async Task<ActionResult<List<PaymentDto>>> GetPayments()
        {
            return await _stripeService.GetPayments();
        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
            return await _stripeService.GetCustomers();
        }
    }
}