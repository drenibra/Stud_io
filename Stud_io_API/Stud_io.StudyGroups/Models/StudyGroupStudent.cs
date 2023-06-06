namespace Stud_io.StudyGroups.Models
{
    public class StudyGroupStudent
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}
