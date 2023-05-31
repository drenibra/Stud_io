using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Resource>? Resources { get; set; }
        public int GroupSettingsId { get; set; }
        public GroupSettings GroupSettings { get; set; }
        public List<GroupEvent>? GroupEvents { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}