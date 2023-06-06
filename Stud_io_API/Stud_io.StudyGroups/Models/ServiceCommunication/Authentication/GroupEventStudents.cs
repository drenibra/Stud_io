namespace Stud_io.StudyGroups.Models.ServiceCommunication.Authentication
{
    public class GroupEventStudents
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int GroupEventId { get; set; }
        public GroupEvent GroupEvent { get; set; }
    }
}
