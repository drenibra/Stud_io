using Stud_io.StudyGroups.DTOs.ServiceCommunication;

namespace Stud_io.StudyGroups.DTOs
{
    public class StudyGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupImageUrl { get; set; }
        public int MajorId { get; set; }
        public List<StudentMemberDto> Members { get; set; }
    }
    public class CreateStudyGroupDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? GroupImage { get; set; }
        public int MajorId { get; set; }
    }
}
