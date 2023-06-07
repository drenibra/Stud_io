namespace Stud_io_Notifications.Configurations
{
    public interface INotificationsDatabaseSettings
    {
        string DeadlinesCollectionName { get; set; }
        string AnnouncementsCollectionName { get; set; }
        string InformationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}