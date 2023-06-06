using Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth;

namespace Stud_io.StudyGroups.DTOs
{
    public class StudyGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupImageUrl { get; set; }
        public int MajorId { get; set; }
        public List<MemberStudentDto> Students { get; set; }
        public List<GroupEventDto> GroupEvents { get; set; }
        public List<PostDto> Posts { get; set; }
    }
    public class CreateStudyGroupDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? GroupImage { get; set; }
        public int MajorId { get; set; }
    }
}
