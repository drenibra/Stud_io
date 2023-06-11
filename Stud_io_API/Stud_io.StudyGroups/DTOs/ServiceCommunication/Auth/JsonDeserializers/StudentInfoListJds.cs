namespace Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth.JsonDeserializers
{
    public class StudentInfoListJds
    {
        public Result result { get; set; }
        public object value { get; set; }
    }

    public class Result
    {
        public List<Value> value { get; set; }
        public object[] formatters { get; set; }
        public object[] contentTypes { get; set; }
        public object declaredType { get; set; }
        public int statusCode { get; set; }
    }

    //it takes it from the StudentInfoJds class => public class Value

}
