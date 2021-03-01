using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KululaServices.Models
{
    public class kululaContext:DbContext
    {
        public kululaContext() : base("kululaServices")
        {

        }
        public DbSet<Client> clients { get; set; }
        public DbSet<Carhire> Carhires { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MemberDiscount> MemberDiscounts { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<SeatBooking> SeatBookings { get; set; }
        public DbSet<FlightBook> FlightBooks { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        //public DbSet<FlightExtra> FlightExtras { get; set; }
        // public DbSet<Traveller> Travellers { get; set; }
    }
}
//Enable-Migrations -ContextTypeName kululaContext -MigrationsDirectory Migrations\kulula_V4
//add-migration -ConfigurationTypeName KululaServices.Migrations.kulula_V4.Configuration "InitialCreate" 
//update-database -ConfigurationTypeName KululaServices.Migrations.kulula_V4.Configuration 
/* Enable-Migrations -ContextTypeName ApplicationDbContext -MigrationsDirectory Migrations\Identity
add-migration -ConfigurationTypeName KululaServices.Migrations.Identity.Configuration "InitialIdentity"
update-database -ConfigurationTypeName KululaServices.Migrations.Identity.Configuration */
