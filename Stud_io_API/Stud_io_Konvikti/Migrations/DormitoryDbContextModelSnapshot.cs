﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stud_io_Dormitory.Configurations;

#nullable disable

namespace Stud_io.Dormitory.Migrations
{
    [DbContext(typeof(DormitoryDbContext))]
    partial class DormitoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stud_io.Dormitory.Models.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("havingGuests")
                        .HasColumnType("bit");

                    b.Property<string>("roomCleanliness")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("shareBelongings")
                        .HasColumnType("bit");

                    b.Property<string>("sleepingHabits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("Stud_io.Dormitory.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DormitoryId")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DormitoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Stud_io_Dormitory.Models.Dormitory", b =>
                {
                    b.Property<int>("DormNo")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStudents")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("NoOfRooms")
                        .HasColumnType("int");

                    b.HasKey("DormNo");

                    b.ToTable("Dormitories");
                });

            modelBuilder.Entity("Stud_io.Dormitory.Models.Room", b =>
                {
                    b.HasOne("Stud_io_Dormitory.Models.Dormitory", "Dormitory")
                        .WithMany("Rooms")
                        .HasForeignKey("DormitoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dormitory");
                });

            modelBuilder.Entity("Stud_io_Dormitory.Models.Dormitory", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
