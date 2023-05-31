using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class GroupSettings
    {
        public int Id { get; set; }
        [ForeignKey("StudyGroup")]
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
        public Boolean RequireApproval { get; set; }
        public Boolean CanInviteMembers { get; set; }
        public int AccessControlId { get; set; }
        public GroupAccessControl AccessControl { get; set; }
        public string AdminId { get; set; }
        public Student Admin { get; set; }
    }
}