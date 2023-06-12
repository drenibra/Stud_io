namespace Stud_io.Dormitory.DTOs
{
    public class RoomDto
    {
        public int RoomNo { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public int DormitoryId { get; set; }
    }

    public class UpdateRoomDto
    {
        public int? RoomNo { get; set; }
        public int? Floor { get; set; }
        public int? Capacity { get; set; }
        public int? DormitoryId { get; set; }
    }
}
