﻿using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.Models;
using Stud_io_Dormitory.Models;

namespace Stud_io_Dormitory.Configurations
{
    public class DormitoryDbContext : DbContext
    {
        public DormitoryDbContext(DbContextOptions<DormitoryDbContext> options) : base(options)
        {

        }

        public DbSet<Dormitory> Dormitories { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Questionnaire> Questionnaires { get; set; } = null!;

    }
}
