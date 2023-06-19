namespace Stud_io.Authentication.DTOs.ServiceCommunication.Dormitory
{
    public class DormitoryStudentDto
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public char? Gender { get; set; }
        public Boolean? isAccepted { get; set; }
        public int? DormNumber { get; set; }
    }
}
