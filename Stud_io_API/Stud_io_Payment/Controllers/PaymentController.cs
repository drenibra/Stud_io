/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using Stud_io.Payment.Models;
using Stud_io_Payment.Configurations;
using Stud_io_Payment.Models;
using Stud_io_Payment.Services.Implementation;

namespace Stud_io_Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        //[Authorize]
        [HttpPost("payment")]
        public async Task<ActionResult> CreateOrUpdatePaymentIntent(double amount, string type)
        {
            Payment p = new Payment()
            {
                TypeOfPayment = type,
                DateOfPayment = DateTime.Now,
                PaymentAmount = Convert.ToDouble(amount),
            };

            await _paymentService.CreateOrUpdatePaymentIntent(p);
            return Ok("Pagesa u krye!");
        }
    }
}*/