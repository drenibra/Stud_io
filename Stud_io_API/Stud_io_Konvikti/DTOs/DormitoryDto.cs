namespace Stud_io_Dormitory.DTOs
{
    public class DormitoryDto
    {
        public string Major { get; set; } = null!;
        public char Gender { get; set; }
        public int NoOfRooms { get; set; }
    }

    public class UpdateDormitoryDto
    {
        public string? Major { get; set; }
        public char? Gender { get; set; }
        public int? NoOfRooms { get; set; }
    }
}
