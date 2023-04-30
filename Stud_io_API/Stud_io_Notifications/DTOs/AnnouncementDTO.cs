namespace Stud_io_Notifications.DTOs
{
    public class AnnouncementDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DeadlineId { get; set; }
    }


    public class UpdateAnnouncementDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? DeadlineId { get; set; }
    }
}
