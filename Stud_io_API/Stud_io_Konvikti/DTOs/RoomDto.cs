namespace Stud_io.Dormitory.DTOs
{
    public class RoomDto
    {
        public int Floor { get; set; }
        public int Capacity { get; set; }
    }

    public class UpdateRoomDto
    {
        public int? Floor { get; set; }
        public int? Capacity { get; set; }
    }
}
