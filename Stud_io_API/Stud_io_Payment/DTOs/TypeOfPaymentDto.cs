namespace Stud_io.Payment.DTOs
{
    public class TypeOfPaymentDto
    {
        public string Type { get; set; } = null!;
        public double Price { get; set; }
    }

    public class UpdateTypeOfPaymentDto
    {
        public string? Type { get; set; }
        public double? Price { get; set; }
    }
}