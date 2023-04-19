namespace Stud_io_Payment.DTOs
{
    public class HistoryDto
    {
        public string Payment { get; set; } = null!;
        public string StdPersonalNo { get; set; } = null!;
    }

    public class UpdateHistoryDto
    {
        public string? Payment { get; set; }
        public string? StdPersonalNo { get; set; }
    }
}
