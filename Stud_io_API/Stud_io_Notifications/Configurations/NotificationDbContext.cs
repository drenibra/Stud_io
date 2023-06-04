using Microsoft.EntityFrameworkCore;
using Stud_io_Notifications.Models;


namespace Stud_io_Notifications.Configurations

{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {

        }

        public DbSet<Information> Informations { get; set; }
    }
}