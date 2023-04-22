namespace Stud_io.Maintenance.DTOs
{
    public class GetDormComplaintDto : GetComplaintDto
    {
        public int FloorNo { get; set; }
    }

    public class CreateDormComplaintDto : CreateComplaintDto
    {
        public int FloorNo { get; set; }
    }

    public class UpdateDormComplaintDto : UpdateComplaintDto
    {
        public int FloorNo { get; set; }
    }
}
