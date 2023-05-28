using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Models;

namespace Stud_io.Application.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<PDF> Pdf { get; set; }
        public DbSet<PNG> Png { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<ApplicationForm> Applications { get; set; }
        public DbSet<ProfileMatch> ProfileMatches { get; set; }
    }
}
