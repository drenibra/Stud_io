namespace Stud_io.Application.Models.ServiceCommunication.Authentication
{
    public class StudentByIdDto
    {
        public object result { get; set; }
        public Value value { get; set; }
    }
    public class Value
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object token { get; set; }
        public string username { get; set; }
        public object image { get; set; }
    }
}
