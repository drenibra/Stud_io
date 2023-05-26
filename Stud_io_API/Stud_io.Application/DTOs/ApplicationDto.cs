namespace Stud_io.Application.DTOs
{
    public class ApplicationDto
    {
        public bool isSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public DateTime ApplyDate { get; set; }
        public string PersonalNo { get; set; }
        public int? StudentId { get; set; }
        public int? FileId { get; set; }
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
}
