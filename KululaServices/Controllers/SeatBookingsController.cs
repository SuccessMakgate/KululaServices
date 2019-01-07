using KululaServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KululaServices.Controllers
{
    [RoutePrefix("api/SeatBookings")]
    public class SeatBookingsController : ApiController
    {
        private kululaContext db = new kululaContext();
        //==============================GET(Get All SeatBooked ): api/SeatBookings===================================================================================

        public IQueryable<SeatBooking> GetSeatBookings()
        {
            return db.SeatBookings;
        }
        //==============================GET(Get Specifit SeatBooked): api/SeatBookings/{Id}====================================================================================

        [Route("{id}")]
        [ResponseType(typeof(Aircraft))]
        public IHttpActionResult GetSeatBooking(int id)
        {
            string FlightSchedID_AircraftId = id.ToString();
            int flightId = 1;
            for (int x = 0; x <= FlightSchedID_AircraftId.Length - 1; x++)
            {
                id = Int32.Parse(FlightSchedID_AircraftId[0].ToString());
                flightId = Int32.Parse(FlightSchedID_AircraftId[1].ToString());
            }


            FlightSchedule schedule = db.FlightSchedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            List<Aircraft> Flight = new List<Aircraft>();
            Flight = schedule.aircrafts.Where(a => a.AircraftId == flightId).ToList();


            return Ok(Flight);
        }

        //=========================================PUT(Modify SeatBook): api/SeatBookings/5===================================================================================

        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeatBooking(int id, SeatBooking seatBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seatBooking.SeatBookingId)
            {
                return BadRequest();
            }

            db.Entry(seatBooking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        //==========================================POST(SeatBook): api/SeatBookings================================================================================


        [ResponseType(typeof(SeatBooking))]
        public IHttpActionResult PostSeatBooking(SeatBooking seatBooking)
        {
            Aircraft Number_of_Seats = db.Aircrafts.Find(seatBooking.AircraftId);
            if (seatBooking.SeatName == "Standard Seat") seatBooking.SeatPrice = 0;
            else if (seatBooking.SeatName == "Aisle chair") seatBooking.SeatPrice = 250;
            else if (seatBooking.SeatName == "window seat") seatBooking.SeatPrice = 300;
            else if (seatBooking.SeatName == "amenities Seat") seatBooking.SeatPrice = 800;
            else if (seatBooking.SeatName == "First Class Seat") seatBooking.SeatPrice = 1000;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            seatBooking.SeatNumber = Number_of_Seats.NumSeatBooked - seatBooking.SeatNumber;
            db.SeatBookings.Add(seatBooking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seatBooking.SeatBookingId }, seatBooking);
        }
        //===========================================POST(Flight Extras): api/SeatBookings/extras=======================================================================

        [Route("extras")]
        [ResponseType(typeof(FlightExtra))]
        public IHttpActionResult PostSeatBooking(FlightExtra flightExtra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.FlightExtras.Add(flightExtra);
           // db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flightExtra.FlightExtraId }, flightExtra);
        }
        //==========================================POST(Flight Travellers): api/SeatBookings/travellers===============================================================================

        [Route("travellers")]
        [ResponseType(typeof(Traveller))]
        public IHttpActionResult PostTraveller(Traveller traveller)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // db.Travellers.Add(traveller);
           // db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = traveller.TravellerId }, traveller);
        }


        // DELETE: api/SeatBookings/5
        [ResponseType(typeof(SeatBooking))]
        public IHttpActionResult DeleteSeatBooking(int id)
        {
            SeatBooking seatBooking = db.SeatBookings.Find(id);
            if (seatBooking == null)
            {
                return NotFound();
            }

            db.SeatBookings.Remove(seatBooking);
            db.SaveChanges();

            return Ok(seatBooking);
        }

        //==================================================================================================================================================
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //==================================================================================================================================================
        private SeatBooking currentSeatbook()
        {
            int MaxRow = db.SeatBookings.Count() - 1;
            List<SeatBooking> allSeatbooks = new List<SeatBooking>();
            allSeatbooks = db.SeatBookings.ToList();
            SeatBooking currentSeatbook = allSeatbooks.ElementAtOrDefault(MaxRow);

            return currentSeatbook;
        }
        //==================================================================================================================================================
        private bool SeatBookingExists(int id)
        {
            return db.SeatBookings.Count(e => e.SeatBookingId == id) > 0;
        }
    }
}
