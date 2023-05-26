using Payment.Contracts;
using Payment.Models.Stripe;
using Stripe;
using Stud_io_Payment.Configurations;

namespace Payment.Application
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly PaymentDbContext _context;

        public StripeAppService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService, 
            PaymentDbContext context)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _context = context;
        }

        private StripeCustomer MapStripeCustomer(Customer customer)
        {
            return new StripeCustomer(customer.Name, customer.Email, customer.Id);
        }

        public async Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct)
        {
            // Set Stripe Token options based on customer data
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExpirationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.Cvc
                }
            };

            // Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = stripeToken.Id
            };

            // Create customer at Stripe
            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);
            StripeCustomer mappedCustomer = MapStripeCustomer(createdCustomer);
            await _context.StripeCustomers.AddAsync(mappedCustomer, ct);
            await _context.SaveChangesAsync(ct);

            // Return the created customer at stripe
            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }

        private StripePayment MapStripePayment(Charge charge)
        {
            return new StripePayment(
                charge.CustomerId,
                charge.ReceiptEmail,
                charge.Description,
                charge.Currency,
                charge.Amount,
                charge.Id);
        }

        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            // Set the options for the payment we would like to create at Stripe
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = payment.CustomerId,
                ReceiptEmail = payment.ReceiptEmail,
                Description = payment.Description,
                Currency = payment.Currency,
                Amount = payment.Amount
            };

            // Create the payment
            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);
            StripePayment mappedPayment = MapStripePayment(createdPayment);
            await _context.StripePayments.AddAsync(mappedPayment);
            await _context.SaveChangesAsync(ct);

            // Return the payment to requesting method
            return new StripePayment(
              createdPayment.CustomerId,
              createdPayment.ReceiptEmail,
              createdPayment.Description,
              createdPayment.Currency,
              createdPayment.Amount,
              createdPayment.Id);
        }
    }
}