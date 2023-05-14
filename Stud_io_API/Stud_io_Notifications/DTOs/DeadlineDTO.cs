using System.ComponentModel.DataAnnotations;

namespace Stud_io_Notifications.DTOs
{
    public class DeadlineDTO
    {
        public string Name { get; set; }


        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ClosedDate { get; set; }
    }

    public class UpdateDeadlineDTO
    {
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OpenDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ClosedDate { get; set; }
    }
}
