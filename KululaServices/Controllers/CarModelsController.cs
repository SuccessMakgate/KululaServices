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
    [RoutePrefix("api/CarModels")]
    public class CarModelsController : ApiController
    {
        private kululaContext db = new kululaContext();

        // GET: api/CarModels
        public IQueryable<CarModel> GetCarModels()
        {
            return db.CarModels;
        }

        // GET: api/CarModels/5
        [Route("{id:alpha}/model")]
        [ResponseType(typeof(CarModel))]
        public IHttpActionResult GetCarModel(string id)
        {
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return NotFound();
            }

            return Ok(carModel);
        }

        [Route("{id:alpha}/pic")]
        [ResponseType(typeof(string))]
        public string GetCarPic(string id)
        {
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return null;
            }

            return carModel.carImage;
        }

        // PUT: api/CarModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarModel(string id, CarModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carModel.CarName)
            {
                return BadRequest();
            }

            db.Entry(carModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
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

        // POST: api/CarModels
        [ResponseType(typeof(CarModel))]
        public HttpResponseMessage PostCarModel()
        {
            string imageName = null;
            bool leatherSeat = false, airbag=false, radio_Cd = false;

            var httpReququest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpReququest.Files["Image"];
            //Create Custom File
            int brk = 0;
            imageName = Path.GetFileNameWithoutExtension(postedFile.FileName);
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);
            if (bool.TryParse(httpReququest["AirBag"], out airbag)) airbag = true;
            if (bool.TryParse(httpReququest["LeatherSeat"],out leatherSeat)) leatherSeat = true;
            if (bool.TryParse(httpReququest["Radio_Cd"],out radio_Cd)) radio_Cd = true;
            CarModel car = new CarModel()
            {
                carImage = imageName,//httpReququest["ImageCaption"],
                CarName= httpReququest["CarName"],
                CarColour = httpReququest["CarColour"],
                YearModel = httpReququest["YearModel"],
                AirBag=airbag,
                LeatherSeat = leatherSeat,
                Radio_Cd = radio_Cd,
                price = Int32.Parse(httpReququest["price"])
            };

            db.CarModels.Add(car);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.CarModels.Add(carModel);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (CarModelExists(carModel.CarName))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

           // return CreatedAtRoute("DefaultApi", new { id = carModel.CarName }, carModel);
        }

        // DELETE: api/CarModels/5
        [ResponseType(typeof(CarModel))]
        public IHttpActionResult DeleteCarModel(string id)
        {
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return NotFound();
            }

            db.CarModels.Remove(carModel);
            db.SaveChanges();

            return Ok(carModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarModelExists(string id)
        {
            return db.CarModels.Count(e => e.CarName == id) > 0;
        }
    }
}