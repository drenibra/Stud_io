namespace Stud_io.Maintenance.DTOs
{
    public class GetDiscontentComplaintDto : GetComplaintDto
    {
        public int ApplicationId { get; set; }
    }

    public class CreateDiscontentComplaintDto : CreateComplaintDto
    {
        public int ApplicationId { get; set; }
    }

    public class UpdateDiscontentComplaintDto : UpdateComplaintDto
    {
        public int ApplicationId { get; set; }
    }

    public class FilterDiscontentComplaintDto : FilterComplaintDto
    {
        public int? ApplicationId { get; set; }
    }
}