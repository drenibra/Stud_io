/*using Stripe;
using Stud_io_Payment.Models;

namespace Stud_io_Payment.Services.Implementation
{
    public class PaymentService
    {
        private readonly IConfiguration _config;

        public PaymentService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(Payment payment)
        {
            var service = new PaymentIntentService();

            var intent = new PaymentIntent();
            var subtotal = payment.PaymentAmount;


            if (string.IsNullOrEmpty(payment.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)subtotal*100,
                    Currency = "eur",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options);
                payment.PaymentIntentId = intent.Id;
                payment.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)payment.PaymentAmount,
                };
                await service.UpdateAsync(payment.PaymentIntentId, options);
            }

            return intent;
        }
    }
}
*/