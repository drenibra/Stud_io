using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.Models;
using Stud_io.Authentication.Models.ServiceCommunications.StudyGroup;
using static System.Net.Mime.MediaTypeNames;

namespace Stud_io.Configuration
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<AppUser>("AppUser")
                .HasValue<Student>("Student");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudyGroupStudent> StudyGroupStudents { get; set; }
        public DbSet<GroupEventStudents> GroupEventStudents { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
