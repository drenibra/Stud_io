namespace Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth.JsonDeserializers
{
    //i use this JDS when I make a call to the auth microservice method GetUserById
    public class StudentInfoJds
    {
        public object result { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string token { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string profileImage { get; set; }
        public string gender { get; set; }
    }

}
