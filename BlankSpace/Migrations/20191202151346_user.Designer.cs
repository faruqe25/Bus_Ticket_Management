﻿// <auto-generated />
using System;
using BlankSpace.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlankSpace.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191202151346_user")]
    partial class user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlankSpace.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("DOB");

                    b.Property<long>("Mobile");

                    b.Property<string>("Name");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");

                    b.HasData(
                        new { AgentId = 1, Address = "Null", DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Mobile = 0L }
                    );
                });

            modelBuilder.Entity("BlankSpace.Models.AssignedDriver", b =>
                {
                    b.Property<int>("AssignedDriverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusId");

                    b.Property<int>("DriverId");

                    b.HasKey("AssignedDriverId");

                    b.HasIndex("BusId");

                    b.HasIndex("DriverId");

                    b.ToTable("AssignedDrivers");
                });

            modelBuilder.Entity("BlankSpace.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusNumber");

                    b.Property<string>("CoachName");

                    b.Property<int>("TotalSeat");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BlankSpace.Models.BusSchedule", b =>
                {
                    b.Property<int>("BusScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusId");

                    b.Property<int>("Destination");

                    b.Property<int>("StartingFrom");

                    b.Property<int>("TicketPrice");

                    b.Property<string>("Time");

                    b.HasKey("BusScheduleId");

                    b.HasIndex("BusId");

                    b.HasIndex("StartingFrom");

                    b.ToTable("BusSchedules");
                });

            modelBuilder.Entity("BlankSpace.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("LicenseNumber");

                    b.Property<long>("Mobile");

                    b.Property<string>("Name");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("BlankSpace.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Mobile");

                    b.Property<string>("Name");

                    b.HasKey("PassengerId");

                    b.ToTable("Passengers");

                    b.HasData(
                        new { PassengerId = 1, Mobile = 0L, Name = "Null" }
                    );
                });

            modelBuilder.Entity("BlankSpace.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlaceName");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("BlankSpace.Models.RoleType", b =>
                {
                    b.Property<int>("RoleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName");

                    b.HasKey("RoleTypeId");

                    b.ToTable("RoleTypes");

                    b.HasData(
                        new { RoleTypeId = 1, RoleName = "Admin" }
                    );
                });

            modelBuilder.Entity("BlankSpace.Models.TicketReservation", b =>
                {
                    b.Property<int>("TicketReservationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId");

                    b.Property<int>("BusScheduleId");

                    b.Property<bool>("ConfirmStatus");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PassengerId");

                    b.Property<string>("SeatNumber");

                    b.HasKey("TicketReservationId");

                    b.HasIndex("AgentId");

                    b.HasIndex("BusScheduleId");

                    b.HasIndex("PassengerId");

                    b.ToTable("TicketReservations");
                });

            modelBuilder.Entity("BlankSpace.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<int>("RoleTypeId");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("RoleTypeId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1, Password = "admin", RoleTypeId = 1, UserName = "admin@whitespace.com" }
                    );
                });

            modelBuilder.Entity("BlankSpace.Models.AssignedDriver", b =>
                {
                    b.HasOne("BlankSpace.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlankSpace.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlankSpace.Models.BusSchedule", b =>
                {
                    b.HasOne("BlankSpace.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlankSpace.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("StartingFrom")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlankSpace.Models.TicketReservation", b =>
                {
                    b.HasOne("BlankSpace.Models.Agent", "Agent")
                        .WithMany("TicketReservations")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlankSpace.Models.BusSchedule", "BusSchedule")
                        .WithMany("TicketReservations")
                        .HasForeignKey("BusScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlankSpace.Models.Passenger", "Passenger")
                        .WithMany("TicketReservations")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlankSpace.Models.User", b =>
                {
                    b.HasOne("BlankSpace.Models.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
