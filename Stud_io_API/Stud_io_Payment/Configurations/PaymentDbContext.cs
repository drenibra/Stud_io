using Microsoft.EntityFrameworkCore;
using Payment.Models.Stripe;
using Stud_io.Payment.Models;

namespace Stud_io_Payment.Configurations
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext>options) : base(options)
        {

        }

        public DbSet<TypeOfPayment> TypeOfPayments { get; set; } = null!;
        public DbSet<StripeCustomer> StripeCustomers { get; set; } = null!;
        public DbSet<StripePayment> StripePayments { get; set; } = null!;
    }
}
