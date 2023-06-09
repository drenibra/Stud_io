using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stud_io.StudyGroups.Models;

namespace Stud_io.Configuration
{
    public class ApplicationDbContext : DbContext //IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<AppUser>()
            //    .HasDiscriminator<string>("Discriminator")
            //    .HasValue<AppUser>("AppUser")
            //    .HasValue<Student>("Student");
        }
        //public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<GroupEvent> GroupEvents { get; set; }
        public DbSet<GroupSettings> GroupSettings { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLikes> CommentLikes { get; set; }
    }
}
