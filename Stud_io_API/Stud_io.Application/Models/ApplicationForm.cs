using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.Application.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public string PersonalNo { get; set; }
        public bool isSpecialCategory { get; set; }
        public string? SpecialCategoryReason { get; set; }
        public DateTime ApplyDate { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("FileDetails")]
        public int? FileId { get; set; }
        public FileDetails FileDetails { get; set; }
    }
}
