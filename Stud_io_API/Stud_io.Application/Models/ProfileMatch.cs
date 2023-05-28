namespace Stud_io.Application.Models
{
    public class ProfileMatch
    {
        public int Id { get; set; }
        public int PointsForGPA { get; set; }
        public int PointsForCity { get; set; }
        public int ExtraPoints { get; set; }
        public int TotalPoints { get; set; }

        public int ApplicationId { get; set; }
        public ApplicationForm Application { get; set; }
    }
}
