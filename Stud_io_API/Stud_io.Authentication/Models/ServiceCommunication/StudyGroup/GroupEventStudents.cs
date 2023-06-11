namespace Stud_io.Authentication.Models.ServiceCommunications.StudyGroup
{
    public class GroupEventStudents
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public int GroupEventId { get; set; }
    }
}
