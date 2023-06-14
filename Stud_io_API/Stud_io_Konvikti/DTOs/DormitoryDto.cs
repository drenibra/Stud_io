namespace Stud_io_Dormitory.DTOs
{
    public class DormitoryDto
    {
        public int DormNo { get; set; }
        public char Gender { get; set; }
        public int NoOfRooms { get; set; }
        public int Capacity { get; set; }
        public int CurrentStudents { get; set; }
    }

    public class UpdateDormitoryDto
    {
        public int? DormNo { get; set; }
        public char? Gender { get; set; }
        public int? NoOfRooms { get; set; }
        public int? Capacity { get; set; }
        public int? CurrentStudents { get; set; }
    }
}
