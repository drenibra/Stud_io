namespace Stud_io.Maintenance.DTOs
{
    public class GetSocialComplaintDto : GetComplaintDto
    {
        public int ComplainedRoomNo { get; set; }
    }

    public class CreateSocialComplaintDto : CreateComplaintDto
    {
        public int ComplainedRoomNo { get; set; }
    }

    public class UpdateSocialComplaintDto : UpdateComplaintDto
    {
        public int ComplainedRoomNo { get; set; }
    }

    public class FilterSocialComplaintDto : FilterComplaintDto
    {
        public int? ComplainedRoomNo { get; set; }
    }
}
