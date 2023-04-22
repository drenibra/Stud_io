using System.ComponentModel.DataAnnotations;

namespace Stud_io.Dormitory.Models
{
    public class Room
    {
        [Key]
        public int RoomNo { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

    }
}
