﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stud_io.Application.Configurations;

#nullable disable

namespace Stud_io.Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230523054849_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Stud_io.Application.Models.FileDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FileDetails");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FileDetails");
                });

            modelBuilder.Entity("Stud_io.Application.Models.Student", b =>
                {
                    b.Property<string>("PersonalNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcademicYear")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNo")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePicUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Stud_io.Application.Models.PDF", b =>
                {
                    b.HasBaseType("Stud_io.Application.Models.FileDetails");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("PDF");
                });

            modelBuilder.Entity("Stud_io.Application.Models.PNG", b =>
                {
                    b.HasBaseType("Stud_io.Application.Models.FileDetails");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("PNG");
                });
#pragma warning restore 612, 618
        }
    }
}