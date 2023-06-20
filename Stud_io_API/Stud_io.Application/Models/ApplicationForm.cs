using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.Application.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = null!;
        public bool IsSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? FileUrl { get; set; }
    }
}
