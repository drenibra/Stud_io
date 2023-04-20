using System.ComponentModel.DataAnnotations;

namespace Stud_io_Notifications.Models
{
    public class Deadline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ClosedDate { get; set; }
    }
}
