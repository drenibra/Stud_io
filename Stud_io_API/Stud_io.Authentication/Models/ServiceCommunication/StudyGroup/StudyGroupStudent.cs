using Stud_io.Models;

namespace Stud_io.Authentication.Models.ServiceCommunications.StudyGroup
{
    public class StudyGroupStudent
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public int StudyGroupId { get; set; }
    }
}
