namespace Stud_io.Maintenance.Models
{
    public class DormComplaint : Complaint
    {
        public int FloorNo { get; set; }
        public string Type { get; set; } = null!;
    }
}
