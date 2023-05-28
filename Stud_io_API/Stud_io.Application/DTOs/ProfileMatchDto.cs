namespace Stud_io.Application.DTOs
{
    public class ProfileMatchDto
    {
        public int PointsForGPA { get; set; }
        public int PointsForCity { get; set; }
        public int ExtraPoints { get; set; }
        public int TotalPoints { get; set; }
        public int ApplicationId { get; set; }
    }

    public class UpdateProfileMatchDto
    {
        public int? PointsForGPA { get; set; }
        public int? PointsForCity { get; set; }
        public int? ExtraPoints { get; set; }
        public int? TotalPoints { get; set; }
        public int? ApplicationId { get; set; }
    }
}
