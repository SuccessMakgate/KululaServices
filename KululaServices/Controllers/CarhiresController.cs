using KululaServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KululaServices.Controllers
{
    public class CarhiresController : ApiController
    {
        private kululaContext dbCarhire = new kululaContext();

        //*******************************************Get List of car Hired *************************************************************************
        // GET: api/Carhires
        public IQueryable<Carhire> GetCarhires()
        {
            return dbCarhire.Carhires;
        }

        //*******************************************Get Specefic car Hired *************************************************************************
        // GET: api/Carhires/5
        [ResponseType(typeof(Carhire))]
        public IHttpActionResult GetCarhire(int id)
        {
            Carhire carhire = dbCarhire.Carhires.Find(id);
            if (carhire == null)
            {
                return NotFound();
            }

            return Ok(carhire);
        }


        //*******************************************Post Carhire *************************************************************************
        // POST: api/Carhires
        [ResponseType(typeof(Carhire))]
        public IHttpActionResult PostCarhire(Carhire carhire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<CarModel> carmodel = new List<CarModel>();


            dbCarhire.Carhires.Add(carhire);
            dbCarhire.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carhire.carHireId }, carhire);
        }

        private bool CarhireExists(int id)
        {
            return dbCarhire.Carhires.Count(e => e.carHireId == id) > 0;
        }
    }
}
