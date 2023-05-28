namespace Payment.Models.Stripe
{
    public class StripePayment
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ReceiptEmail { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public long Amount { get; set; }
        public string PaymentId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string Month { get; set; }

        public StripePayment(string customerId, string receiptEmail, string description, string currency, long amount, string paymentId, DateTime dateOfPayment, string month)
        {
            CustomerId = customerId;
            ReceiptEmail = receiptEmail;
            Description = description;
            Currency = currency;
            Amount = amount;
            PaymentId = paymentId;
            DateOfPayment = dateOfPayment;
            Month = month;
        }
    }
}