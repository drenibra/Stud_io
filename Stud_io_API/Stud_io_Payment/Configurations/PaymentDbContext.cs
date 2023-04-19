using Microsoft.EntityFrameworkCore;
using Stud_io_Payment.Models;

namespace Stud_io_Payment.Configurations
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext>options) : base(options)
        {

        }

        public DbSet<History> Histories { get; set; } = null!;
    }
}
