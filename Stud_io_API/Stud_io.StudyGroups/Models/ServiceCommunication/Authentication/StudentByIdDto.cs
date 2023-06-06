namespace Stud_io.StudyGroups.Models.ServiceCommunication.Authentication
{
    public class StudyGroupStudentsResponse
    {
        public List<StudyGroupStudent> Property1 { get; set; }
    }

    public class StudyGroupStudent
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

}
