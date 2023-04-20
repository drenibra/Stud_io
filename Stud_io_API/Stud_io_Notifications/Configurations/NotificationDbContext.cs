using Microsoft.EntityFrameworkCore;
using Stud_io.Models;
using System;

namespace Stud_io.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {

        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Deadline> Deadlines { get; set; }
        public DbSet<Information> Informations { get; set; }


    }
}
