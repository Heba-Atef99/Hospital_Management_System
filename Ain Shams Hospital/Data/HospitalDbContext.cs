using Ain_Shams_Hospital.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    public class HospitalDbContext:DbContext
    {
        
        

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options):base(options)
        {

        }

      


        public DbSet<Blood_Unit> Blood_Units { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Facility_Reservation> Facility_Reservations { get; set; }
        public DbSet<Follow_Up> Follow_Ups { get; set; }
        public DbSet<Follow_Up_History> Follow_Ups_History { get; set; }
        public DbSet<Follow_Up_Type> Follow_Ups_Types { get; set; }
        public DbSet<Hospital_Facility> Hospital_Facilities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Staff_Schedule> Staff_Schedules { get; set; }
        public DbSet<Transfer_Hospital> Transfer_Hospitals { get; set; }
        
    }
}
