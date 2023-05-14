using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using Stud_io_Payment.Configurations;
using Stud_io_Payment.Services.Implementation;

namespace Stud_io_Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        private readonly PaymentDbContext _context;

        public PaymentController(PaymentService paymentService, PaymentDbContext context)
        {
            _paymentService = paymentService;
            _context = context;
        }

        //[Authorize]
        [HttpPost("payment")]
        public async Task<ActionResult> CreateOrUpdatePaymentIntent(double amount, string type)
        {
            var options = new Stripe.Checkout.SessionCreateOptions
            {
<<<<<<< Updated upstream
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long?)Convert.ToDouble(amount),
                            Currency = "eur"
                        },
                        Quantity = 1
                    },
                },
                Mode = "payment"
=======
                TypeOfPayment = type,
                DateOfPayment = DateTime.Now,
                PaymentAmount = Convert.ToDouble(amount),

>>>>>>> Stashed changes
            };
            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return Ok("Pagesa u krye!");
        }
    }
}
