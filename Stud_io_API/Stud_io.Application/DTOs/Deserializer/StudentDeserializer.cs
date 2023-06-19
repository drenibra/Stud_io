namespace Stud_io.Application.DTOs.Deserializer
{
    public class StudentDeserializer
    {
        public string? id { get; set; }
        public string? email { get; set; }

    }

    public class StudentProfileDeserializer
    {
        public double? gpa { get; set; }
        public string? city { get; set; }
    }
}
