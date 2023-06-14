namespace Stud_io.Authentication.DTOs.PaymentDto
{
    public class PaymentDtos
    {
        public class CustomerDto
        {
            public string Name { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string CustomerId { get; set; } = null!;
        }

        public class PaymentDto
        {
            public string CustomerId { get; set; } = null!;
            public string ReceiptEmail { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string Currency { get; set; } = null!;
            public long Amount { get; set; }
            public string PaymentId { get; set; } = null!;
            public DateTime DateOfPayment { get; set; }
            public string Month { get; set; } = null!;
        }
    }
}