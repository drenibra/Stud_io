namespace Stud_io_Notifications.Configurations
{
    public class NotificationsDatabaseSettings : INotificationsDatabaseSettings
    {
        public string DeadlinesCollectionName { get; set; } = string.Empty;
        public string AnnouncementsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string InformationsCollectionName { get; set; } = string.Empty;
    }
}