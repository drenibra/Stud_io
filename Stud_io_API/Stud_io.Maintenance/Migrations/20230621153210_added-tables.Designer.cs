﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stud_io.Maintenance.Configurations;

#nullable disable

namespace Stud_io.Maintenance.Migrations
{
    [DbContext(typeof(MaintenanceDbContext))]
    [Migration("20230621153210_added-tables")]
    partial class addedtables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stud_io.Maintenance.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DormNo")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("bit");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Complaints");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Complaint");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.DTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DormNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorNo")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MaintenantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.Semundja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecializimiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecializimiId");

                    b.ToTable("Semundjet");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.Specializimi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializimet");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.DiscontentComplaint", b =>
                {
                    b.HasBaseType("Stud_io.Maintenance.Models.Complaint");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscontentComplaint");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.DormComplaint", b =>
                {
                    b.HasBaseType("Stud_io.Maintenance.Models.Complaint");

                    b.Property<int>("FloorNo")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DormComplaint");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.SocialComplaint", b =>
                {
                    b.HasBaseType("Stud_io.Maintenance.Models.Complaint");

                    b.Property<int>("ComplainedRoomNo")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("SocialComplaint");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.Semundja", b =>
                {
                    b.HasOne("Stud_io.Maintenance.Models.Specializimi", "Specializimi")
                        .WithMany("Semundjet")
                        .HasForeignKey("SpecializimiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specializimi");
                });

            modelBuilder.Entity("Stud_io.Maintenance.Models.Specializimi", b =>
                {
                    b.Navigation("Semundjet");
                });
#pragma warning restore 612, 618
        }
    }
}
