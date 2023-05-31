using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public enum AccessControlType
    {
        Public,
        Restricted,
        Private
    }
    public class GroupAccessControl
    {
        public int Id { get; set; }
        [ForeignKey("GroupSettings")]
        public int GroupSettingsId { get; set; }
        public GroupSettings GroupSettings { get; set; }
        public AccessControlType AccessControlType { get; set; }
    }
}
