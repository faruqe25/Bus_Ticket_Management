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
    [Migration("20191124163055_AddMobile")]
    partial class AddMobile
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

                    b.Property<string>("Destination");

                    b.Property<string>("StartingFrom");

                    b.Property<int>("TicketPrice");

                    b.Property<string>("Time");

                    b.HasKey("BusScheduleId");

                    b.HasIndex("BusId");

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
                });

            modelBuilder.Entity("BlankSpace.Models.RoleType", b =>
                {
                    b.Property<int>("RoleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName");

                    b.HasKey("RoleTypeId");

                    b.ToTable("RoleTypes");
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
                        .WithMany()
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
