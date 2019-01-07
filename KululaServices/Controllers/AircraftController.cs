using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KululaServices.Models;
using System.Web;
using System.IO;

namespace KululaServices.Controllers
{
    public class AircraftController : ApiController
    {
        private kululaContext db = new kululaContext();

        // GET: api/Aircraft
        public IQueryable<Aircraft> GetAircrafts()
        {
            return db.Aircrafts;
        }

        // GET: api/Aircraft/5
        [ResponseType(typeof(Aircraft))]
        public IHttpActionResult GetAircraft(int id)
        {
            Aircraft aircraft = db.Aircrafts.Find(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return Ok(aircraft);
        }

        // PUT: api/Aircraft/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAircraft(int id, Aircraft aircraft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aircraft.AircraftId)
            {
                return BadRequest();
            }

            db.Entry(aircraft).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
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

        // POST: api/Aircraft
        [ResponseType(typeof(Aircraft))]
        public HttpResponseMessage PostAircraft()
        {
            string imageName = null;

            var httpReququest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpReququest.Files["Image"];
            //Create Custom File
            int brk = 0;
            imageName = Path.GetFileNameWithoutExtension(postedFile.FileName);
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            Aircraft flight = new Aircraft()
            {
                AircraftLogo = imageName,//httpReququest["ImageCaption"],
                AircraftName = httpReququest["AircraftName"],
                AircraftNo = httpReququest["AircraftNo"],
                price= Int32.Parse(httpReququest["price"]),
                MaxSeats = Int32.Parse(httpReququest["MaxSeats"])
            };

            db.Aircrafts.Add(flight);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Aircrafts.Add(aircraft);
            //db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = aircraft.AircraftId }, aircraft);
        }

        // DELETE: api/Aircraft/5
        [ResponseType(typeof(Aircraft))]
        public IHttpActionResult DeleteAircraft(int id)
        {
            Aircraft aircraft = db.Aircrafts.Find(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            db.Aircrafts.Remove(aircraft);
            db.SaveChanges();

            return Ok(aircraft);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AircraftExists(int id)
        {
            return db.Aircrafts.Count(e => e.AircraftId == id) > 0;
        }
    }
}