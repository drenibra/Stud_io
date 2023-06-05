namespace Stud_io.StudyGroups.Models
{
    public class GroupEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public List<GroupEventStudents> Attendees { get; set; }
        public int Capacity { get; set; }
    }
}