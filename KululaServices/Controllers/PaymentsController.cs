using KululaServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace KululaServices.Controllers
{
    [AllowAnonymous]
    public class PaymentsController : ApiController
    {
        private kululaContext dbPayment = new kululaContext();

        //*******************************************Get List of Payments *************************************************************************
        //  GET: api/Payments
        public IQueryable<Payment> GetCarhires()
        {
            return dbPayment.Payments;
        }

        //  GET: api/Payments/5
        [ResponseType(typeof(Carhire))]
        public IHttpActionResult GetCarhire(int id)
        {
            Payment payment = dbPayment.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }


        //*******************************************Get Carhire Receipt *************************************************************************
        // GET: api/Payments/carhire
        [Route("api/payments/carhire")]
        [ResponseType(typeof(Carhire))]
        public IHttpActionResult GetCarReceipt()
        {

            if(currentCarhire().PaymentStatus)
            {
               return  Ok(currentCarhire());
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        //*******************************************Get SeatBook Receipt *************************************************************************
        // GET: api/Payments/seatbook
        [Route("api/payments/seatbook")]
        [ResponseType(typeof(SeatBooking))]
        public IHttpActionResult GetSeatbookReceipt()
        {

            if (currentSeatbook().PaymentStatus)
            {
                return Ok(currentCarhire());
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //*******************************************Post Payment *************************************************************************
        // POST: api/Payments
        [ResponseType(typeof(Payment))]
        public IHttpActionResult PostPayment(Payment payment)
        {
            string CurrentUser = null;
            if (HttpContext.Current.User.Identity.Name != null) CurrentUser = HttpContext.Current.User.Identity.Name.ToString();
            DateTime TransactionStamp = DateTime.Now;
            payment.TransactionDate = TransactionStamp;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (payment.IsSeatBook == true)
            {
                currentSeatbook().PaymentStatus = true;
                dbPayment.Entry(currentSeatbook()).State = EntityState.Modified;
            }
            else if (payment.IsCarhire == true)
            {
                currentCarhire().PaymentStatus = true;
                dbPayment.Entry(currentCarhire()).State = EntityState.Modified;
            }

            dbPayment.Payments.Add(payment);
            dbPayment.SaveChanges();
            if (CurrentUser != null)
            {
                MemberPayment mPay = new MemberPayment();

                mPay.Email = CurrentUser;
                mPay.discount = 7.5;
                mPay.kululaPoints = 15;
                mPay.TransactionDate = TransactionStamp;
                mPay.PaymentId = payment.PaymentId;


                //dbPayment.MemberPayments.Add(mPay);
                //dbPayment.SaveChanges();
                dbPayment.Entry(mPay).State = EntityState.Added;

            }
            dbPayment.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = payment.PaymentId }, payment);
        }



        //*******************************************Current Carhire *************************************************************************
        private Carhire currentCarhire()
        {
            int MaxRow = dbPayment.Carhires.Count() - 1;
            List<Carhire> allCarhires = new List<Carhire>();
            allCarhires = dbPayment.Carhires.ToList();
            Carhire currentCarhire = allCarhires.ElementAtOrDefault(MaxRow);

            return currentCarhire;
        }

        //*******************************************Current Seatbook*************************************************************************
        private SeatBooking currentSeatbook()
        {
            int MaxRow = dbPayment.SeatBookings.Count() - 1;
            List<SeatBooking> allSeatbooks = new List<SeatBooking>();
            allSeatbooks = dbPayment.SeatBookings.ToList();
            SeatBooking currentSeatbook = allSeatbooks.ElementAtOrDefault(MaxRow);

            return currentSeatbook;
        }
        private bool PaymentExists(int id)
        {
            return dbPayment.Payments.Count(e => e.PaymentId == id) > 0;
        }
    }
}
