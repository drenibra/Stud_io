using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class GroupSettings
    {
        public int Id { get; set; }
        public bool RequireApproval { get; set; }

        public string AdminId { get; set; }
        [ForeignKey("StudyGroup")]
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}