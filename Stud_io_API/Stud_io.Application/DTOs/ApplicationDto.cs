using Microsoft.Extensions.Primitives;

namespace Stud_io.Application.DTOs
{
    public class ApplicationDto
    {
        public bool IsSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public IFormFile? Document { get; set; }
        public string Token { get; set; }
    }

    public class UpdateApplicationDto
    {
        public bool? IsSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string? StudentId { get; set; }
        public string? FileUrl { get; set; }
    }

    public class ApplicationDetailsDto
    {
        public bool IsSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public string? DocumentUrl { get; set; }
        public string StudentId { get; set; } = null!;
    }
}
