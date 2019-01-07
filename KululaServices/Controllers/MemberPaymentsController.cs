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

namespace KululaServices.Controllers
{
    public class MemberPaymentsController : ApiController
    {
        private kululaContext db = new kululaContext();

        // GET: api/MemberPayments
        public IQueryable<MemberPayment> GetMemberPayments()
        {
            return db.MemberPayments;
        }

        // GET: api/MemberPayments/5
        [ResponseType(typeof(MemberPayment))]
        public IHttpActionResult GetMemberPayment(DateTime id)
        {
            //MemberPayment memberPayment = db.MemberPayments.Find(id);
            if (currentMemberPayment() == null)
            {
                return NotFound();
            }

            return Ok(currentMemberPayment());
        }

        // PUT: api/MemberPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMemberPayment(DateTime id, MemberPayment memberPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memberPayment.TransactionDate)
            {
                return BadRequest();
            }

            db.Entry(memberPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberPaymentExists(id))
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

        // POST: api/MemberPayments
        [ResponseType(typeof(MemberPayment))]
        public IHttpActionResult PostMemberPayment(MemberPayment memberPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MemberPayments.Add(memberPayment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MemberPaymentExists(memberPayment.TransactionDate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = memberPayment.TransactionDate }, memberPayment);
        }

        // DELETE: api/MemberPayments/5
        [ResponseType(typeof(MemberPayment))]
        public IHttpActionResult DeleteMemberPayment(DateTime id)
        {
            MemberPayment memberPayment = db.MemberPayments.Find(id);
            if (memberPayment == null)
            {
                return NotFound();
            }

            db.MemberPayments.Remove(memberPayment);
            db.SaveChanges();

            return Ok(memberPayment);
        }
        private MemberPayment currentMemberPayment()
        {
            int MaxRow = db.SeatBookings.Count() - 1;
            List<MemberPayment> allMemberPayments = new List<MemberPayment>();
            allMemberPayments = db.MemberPayments.ToList();
            MemberPayment currentMemberPayment = allMemberPayments.ElementAtOrDefault(MaxRow);

            return currentMemberPayment;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberPaymentExists(DateTime id)
        {
            return db.MemberPayments.Count(e => e.TransactionDate == id) > 0;
        }
    }
}