using Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth;

namespace Stud_io.StudyGroups.DTOs
{

    public class FilterGroupEventDto
    {
        public int StudyGroupId { get; set; }
        public string? Location { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class GroupEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string DateStart { get; set; }
        public string TimeStart { get; set; }
        public string DateEnd { get; set; }
        public string TimeEnd { get; set; }
        public int Duration { get; set; }
        public int StudyGroupId { get; set; }
        public List<MemberStudentDto> Attendees { get; set; }
    }

    public class CreateGroupEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public int StudyGroupId { get; set; }
    }

    public class UpdateGroupEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public int StudyGroupId { get; set; }
    }
}
