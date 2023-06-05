namespace Stud_io.Application.DTOs
{
    public class ApplicationDto
    {
        public bool IsSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public string PersonalNo { get; set; }
        public int StudentId { get; set; }
        public IFormFile? Document { get; set; }
    }

    public class UpdateApplicationDto
    {
        public bool? isSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string? PersonalNo { get; set; }
        public int? StudentId { get; set; }
        public int? FileId { get; set; }
    }

    public class ApplicationDetailsDto
    {
        public bool IsSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public string PersonalNo { get; set; } = null!;
        public string? DocumentUrl { get; set; }
        public string StudentId { get; set; } = null!;
        public StudentDetailsDto StudentDetails { get; set; } = null!;
    }
}
