using Microsoft.EntityFrameworkCore;
using Stud_io.Maintenance.Models;

namespace Stud_io.Maintenance.Configurations
{
    public class MaintenanceDbContext : DbContext
    {
        public MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : base(options)
        {

        }

        public DbSet<DTask> Tasks { get; set; }
    }
}
