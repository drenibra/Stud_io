namespace Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth
{
    //i use this Dto when I make a call to the auth microservice method GetUserById

    public class StudentInfoDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public object Email { get; set; }
        public object ProfileImage { get; set; }
        public string Gender { get; set; }
    }
}
