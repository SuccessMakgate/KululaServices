using KululaServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KululaServices.Controllers
{
    public class FlightBooksController : ApiController
    {
        private kululaContext db = new kululaContext();
        //*******************************************Post Flight Search *************************************************************************
        // POST: api/FlightBooks
        [HttpPost]
        [ResponseType(typeof(FlightBook))]
        public IHttpActionResult SearchFlight(FlightBook flightBook)
        {
            int brk = 0;
            Random rnd = new Random();
            List<Aircraft> RandAircraft = new List<Aircraft>();
            RandAircraft = db.Aircrafts.ToList();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var search = db.FlightSchedules.Where(x => x.DepartDate.Day == flightBook.DepartDate.Day).ToList();
            if (search.Count() != 0)
            {
                foreach (var searches in search)
                {
                    int MaxRows = db.Aircrafts.Count();
                    Aircraft getAircraft = RandAircraft.ElementAtOrDefault(rnd.Next(MaxRows));
                    getAircraft.NumSeatBooked = getAircraft.NumSeatBooked + flightBook.NumPeople;
                    db.Entry(getAircraft).State = EntityState.Modified;
                    searches.aircrafts.Add(getAircraft);


                }
            }

            flightBook.MatchedSchedules = search;
            flightBook.FlightScheduleId = search[0].FlightScheduleId;
            db.FlightBooks.Add(flightBook);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flightBook.FlightBookId }, flightBook);
        }

        //*******************************************Get Flight Schedule *************************************************************************
        [HttpGet]
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult CheckSchedule()//Must Be List Of Schedule ,Then will Select PArticular Array
        {
            int brk = 0;

            int MaxRows = db.FlightBooks.Count() - 1;
            List<FlightBook> RandAircraft = new List<FlightBook>();
            List<FlightSchedule> AllSchedules = new List<FlightSchedule>();
            RandAircraft = db.FlightBooks.ToList();

            FlightBook CurrentBook = RandAircraft.ElementAtOrDefault(MaxRows);

            if (CurrentBook.MatchedSchedules.Count != 0)
            {
                foreach (FlightSchedule schedule in CurrentBook.MatchedSchedules)
                {
                    AllSchedules.Add(schedule);
                }
            }


            return Ok(AllSchedules);
        }


        private bool FlightBookExists(int id)
        {
            return db.FlightBooks.Count(e => e.FlightBookId == id) > 0;
        }
    }
}
