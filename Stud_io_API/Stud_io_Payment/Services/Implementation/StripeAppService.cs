using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment.Contracts;
using Payment.Models.Stripe;
using Stripe;
using Stud_io.Payment.DTOs;
using Stud_io_Payment.Configurations;
using System.Net.Http.Headers;
using System.Text;

namespace Payment.Application
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly PaymentDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public StripeAppService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService,
            PaymentDbContext context,
            IMapper mapper,
            IHttpClientFactory httpClientFactory)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        private static StripeCustomer MapStripeCustomer(Customer customer)
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

            var httpClient = _httpClientFactory.CreateClient();

            var uri = "http://localhost:5274/api/v1/User/update-customer-id/" + mappedCustomer.CustomerId;

            var authentication = new AuthenticationHeaderValue("Bearer", customer.Token);
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var content = new StringContent("", Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(uri, content);
            
            await _context.StripeCustomers.AddAsync(mappedCustomer, ct);
            await _context.SaveChangesAsync(ct);

            // Return the created customer at stripe
            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }

        private static StripePayment MapStripePayment(Charge charge, string month)
        {
            return new StripePayment(
                charge.CustomerId,
                charge.ReceiptEmail,
                charge.Description,
                charge.Currency,
                charge.Amount,
                charge.Id,
                charge.Created,
                month);
        }

        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            try
            {
                bool hasPaid = await HasPaid(payment);
                if (hasPaid)
                    throw new Exception("Pages u kry ma heret!");

                // Set the options for the payment we would like to create at Stripe
                ChargeCreateOptions paymentOptions = new()
                {
                    Customer = payment.CustomerId,
                    ReceiptEmail = payment.ReceiptEmail,
                    Description = payment.Description,
                    Currency = payment.Currency,
                    Amount = payment.Amount
                };

                // Create the payment
                var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);
                StripePayment mappedPayment = MapStripePayment(createdPayment, payment.Month);
                await _context.StripePayments.AddAsync(mappedPayment, ct);
                await _context.SaveChangesAsync(ct);

                // Return the payment to requesting method
                return new StripePayment(
                  createdPayment.CustomerId,
                  createdPayment.ReceiptEmail,
                  createdPayment.Description,
                  createdPayment.Currency,
                  createdPayment.Amount,
                  createdPayment.Id,
                  createdPayment.Created,
                  payment.Month);
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private async Task<bool> HasPaid(AddStripePayment payment)
        {
            var mappedPayment = await _context.StripePayments.Where(c => c.CustomerId == payment.CustomerId).ToListAsync();

            foreach (var c in mappedPayment)
            {
                if(c.Month == payment.Month)
                {
                    if(c.Description == payment.Description)
                    {
                        return true;
                    }
                    string prefix = "Pagesë për ";
                    string strippedString1 = c.Description.Replace(prefix, "").Trim();
                    string strippedString2 = payment.Description.Replace(prefix, "").Trim();

                    if (strippedString1.Contains(strippedString2) || strippedString2.Contains(strippedString1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<ActionResult<List<PaymentDto>>> GetPayments()
        {
            return _mapper.Map<List<PaymentDto>>(await _context.StripePayments.ToListAsync());
        }

        public async Task<ActionResult<List<PaymentDto>>> GetPaymentsOfUser(string customerId)
        {
            List<PaymentDto> payments = _mapper.Map<List<PaymentDto>>(await _context.StripePayments
            .Where(payment => payment.CustomerId == customerId)
            .ToListAsync());

            return payments;
        }

        public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
            return _mapper.Map<List<CustomerDto>>(await _context.StripeCustomers.ToListAsync());
        }
    }
}