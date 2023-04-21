namespace Stud_io_Payment.Models
{
    public class Payment
    {
        public int Id{ get; set; }
        public string TypeOfPayment { get; set; } = null!;
        public DateTime DateOfPayment { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentIntentId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
    }
}
