using BlankSpace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
                
        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet<AssignedDriver> AssignedDrivers { get; set; }
        public DbSet<TicketReservation> TicketReservations { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasData(
                new Agent {
                    Address="Null",
                    AgentId=1,
                    Mobile=0,
                  
                }
                );
            modelBuilder.Entity<Passenger>().HasData(
               new Passenger
               {
                   Name = "Null",
                   PassengerId = 1,
                   Mobile = 0,
               }
               ); 
            modelBuilder.Entity<RoleType>().HasData(
               new RoleType
               {
                   RoleName = "Admin",
                   RoleTypeId = 1,
                  
               }
               );
            modelBuilder.Entity<User>().HasData(
              new User
              {
                  UserId =1,
                  UserName = "admin@gmail.com",
                  Password="admin",
                  RoleTypeId=1

              }
              );
        }

    }
}
