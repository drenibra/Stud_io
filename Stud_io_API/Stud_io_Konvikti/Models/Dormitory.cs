using System.ComponentModel.DataAnnotations;

namespace Stud_io_Dormitory.Models
{
    public class Dormitory
    {
        [Key]
        public int DormNo { get; set; }
        public string Major { get; set; } = null!;
        public char Gender { get; set; }
        public int NoOfRooms { get; set; }
    }
}
