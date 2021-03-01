namespace KululaServices.Migrations.kulula_V4
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<KululaServices.Models.kululaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\kulula_V4";
        }

        protected override void Seed(KululaServices.Models.kululaContext context)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            List<FlightSchedule> FlightSchedule = new List<FlightSchedule>()
            {
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 21:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("15.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("15.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("10.02.2021 15:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("10.02.2021 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("14.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("14.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("11.02.2021 15:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("11.02.2021 15:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("13.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("13.02.2021 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("16.02.2021 11:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("16.02.2021 12:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 17:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("14.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("14.02.2021 22:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("14.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("14.02.2021 21:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("17.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("17.02.2021 18:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("15.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("15.02.2021 17:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.02.2021 17:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.02.2021 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 08:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.02.2021 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 16:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("13.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("13.02.2021 01:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("13.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("13.02.2021 22:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 22:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("13.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("13.02.2021 17:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("17.02.2021 15:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("17.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 16:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("16.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("16.02.2021 21:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 12:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("13.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("13.02.2021 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("13.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("13.02.2021 21:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("16.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("16.02.2021 18:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("16.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("16.02.2021 15:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 14:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 16:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("12.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("12.02.2021 21:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("13.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("13.02.2021 20:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("13.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("13.02.2021 11:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("16.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("16.02.2021 19:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },
                 new FlightSchedule() {
                     DepartDate=DateTime.ParseExact("16.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     DepartTime=DateTime.ParseExact("16.02.2021 10:50:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnDate=DateTime.ParseExact("18.02.2021 12:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                     ReturnTime=DateTime.ParseExact("18.02.2021 13:00:00","dd.MM.yyyy HH:mm:ss",provider,DateTimeStyles.None),
                },


           };
            context.FlightSchedules.AddOrUpdate(t =>t.FlightScheduleId,FlightSchedule.ToArray());

        }
    }
}
