using Microsoft.Extensions.Hosting;
using Stud_io.StudyGroups.Models.ServiceCommunication.Authentication;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupImageUrl { get; set; }

        public List<Post>? Posts { get; set; }
        public List<Resource>? Resources { get; set; }
        public GroupSettings GroupSettings { get; set; }
        public List<GroupEvent>? GroupEvents { get; set; }
        [ForeignKey("MajorId")]
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public List<StudyGroupStudent> Members { get; set; }
    }
}