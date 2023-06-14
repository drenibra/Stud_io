using Stud_io.Dormitory.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io_Dormitory.Models
{
    public class Dormitory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int DormNo { get; set; }
        public char Gender { get; set; }
        public int NoOfRooms { get; set; }
        public int Capacity { get; set; }  //total capacity of dormitory
        public int CurrentStudents { get; set; }

        //navigation prop
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
