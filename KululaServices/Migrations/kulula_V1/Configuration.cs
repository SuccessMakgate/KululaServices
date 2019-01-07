namespace KululaServices.Migrations.kulula_V1
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KululaServices.Models.kululaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\kulula_V1";
        }

        protected override void Seed(KululaServices.Models.kululaContext context)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            
            List<FlightSchedule> FlightSchedule = new List<FlightSchedule>()
            {
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("15.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("15.11.2018 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.11.2018 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("16.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("16.11.2018 17:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.11.2018 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("17.11.2018 15:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("19.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("19.11.2018 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("18.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("18.11.2018 11:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("20.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("20.11.2018 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("19.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("19.11.2018 23:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("23.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("23.11.2018 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("11.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.11.2018 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("13.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("14.11.2018 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("14.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.11.2018 17:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("02.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("03.11.2018 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("05.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("06.11.2018 15:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("07.11.2018 17:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("08.11.2018 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("01.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("18.11.2018 08:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("20.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("20.11.2018 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("21.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("21.11.2018 14:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("24.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("25.11.2018 01:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("22.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("15.11.2018 23:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.11.2018 22:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("16.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("16.11.2018 16:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.11.2018 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.11.2018 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("17.11.2018 12:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("19.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("19.11.2018 21:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("18.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("18.11.2018 11:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("20.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("20.11.2018 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("19.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("19.11.2018 23:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("23.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("23.11.2018 18:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("15.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("15.11.2018 17:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.11.2018 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("16.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("16.11.2018 15:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.11.2018 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("17.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("17.11.2018 23:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("19.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("19.11.2018 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("18.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("18.11.2018 10:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("20.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("20.11.2018 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("19.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("19.11.2018 09:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("23.11.2018 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("23.11.2018 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },


           };
            context.FlightSchedules.AddOrUpdate(t => t.FlightScheduleId, FlightSchedule.ToArray());
        }
    }
 }

