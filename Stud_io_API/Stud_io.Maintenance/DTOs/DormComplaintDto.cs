namespace Stud_io.Maintenance.DTOs
{
    public class GetDormComplaintDto : GetComplaintDto
    {
        public int FloorNo { get; set; }
        public string Type { get; set; } = null!;
    }

    public class CreateDormComplaintDto : CreateComplaintDto
    {
        public int FloorNo { get; set; }
        public string Type { get; set; } = null!;
    }

    public class UpdateDormComplaintDto : UpdateComplaintDto
    {
        public int FloorNo { get; set; }
        public string Type { get; set; } = null!;
    }

    public class FilterDormComplaintDto : FilterComplaintDto
    {
        public string? Type { get; set; }
    }
}