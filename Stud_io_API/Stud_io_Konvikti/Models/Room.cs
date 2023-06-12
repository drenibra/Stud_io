using System.ComponentModel.DataAnnotations;


namespace Stud_io.Dormitory.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

        //navigation properties
        public int DormitoryId { get; set; }
        public Stud_io_Dormitory.Models.Dormitory Dormitory { get; set; }
        
    }
}
