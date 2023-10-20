﻿// <auto-generated />
using System;
using ITManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITManagement.Migrations
{
    [DbContext(typeof(ApplicationITDbContect))]
    [Migration("20231019193013_allTabels")]
    partial class allTabels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkMan.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayDepartament")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Departaments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayDepartament = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            DisplayDepartament = 2,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            DisplayDepartament = 3,
                            Name = "Developers"
                        });
                });

            modelBuilder.Entity("WorkMan.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfHire")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Sebes",
                            Country = "Roumania",
                            DateOfBirth = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(2023, 10, 19, 22, 30, 13, 700, DateTimeKind.Local).AddTicks(1678),
                            DepartamentId = 1,
                            Email = "rfurdui26@gmail.com",
                            FirstName = "Robert",
                            ImageUrl = "",
                            LastName = "Furdui",
                            PhoneNumber = "3746736473",
                            PostalCode = "34234",
                            Salary = 3000.0,
                            State = "AB",
                            StreetAdress = "Tech Aria 156 Street"
                        },
                        new
                        {
                            Id = 2,
                            City = "Sibiu",
                            Country = "Roumania",
                            DateOfBirth = new DateTime(2002, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(2023, 10, 19, 22, 30, 13, 700, DateTimeKind.Local).AddTicks(1733),
                            DepartamentId = 2,
                            Email = "mihaiachi26@gmail.com",
                            FirstName = "Mihai",
                            ImageUrl = "",
                            LastName = "Achimescu",
                            PhoneNumber = "69586988765",
                            PostalCode = "45567",
                            Salary = 6000.0,
                            State = "SB",
                            StreetAdress = "Don Juan 156 Street"
                        },
                        new
                        {
                            Id = 3,
                            City = "LogoRados",
                            Country = "Armenia",
                            DateOfBirth = new DateTime(2000, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(2023, 10, 19, 22, 30, 13, 700, DateTimeKind.Local).AddTicks(1738),
                            DepartamentId = 3,
                            Email = "hank26@gmail.com",
                            FirstName = "Jhon",
                            ImageUrl = "",
                            LastName = "Hank",
                            PhoneNumber = "7857487546584",
                            PostalCode = "99087",
                            Salary = 5600.0,
                            State = "LR",
                            StreetAdress = "Los Angeles 156 Street"
                        });
                });

            modelBuilder.Entity("WorkMan.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishProject")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WorkMan.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WorkMan.Models.Employee", b =>
                {
                    b.HasOne("WorkMan.Models.Departament", "Departament")
                        .WithMany()
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("WorkMan.Models.Project", b =>
                {
                    b.HasOne("WorkMan.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}