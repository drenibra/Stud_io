using System.ComponentModel.DataAnnotations.Schema;
using Stud_io.StudyGroups.Models.ServiceCommunication.Authentication;

namespace Stud_io.StudyGroups.Models
{
    public class GroupEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public List<GroupEventStudents> Attendees { get; set; }

        [ForeignKey("StudyGroupId")]
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}