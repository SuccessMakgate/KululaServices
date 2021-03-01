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
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using System.Net.Mime;

namespace KululaServices.Controllers
{
    public class PaymentsController : ApiController
    {
        private kululaContext dbPayment = new kululaContext();

        //*******************************************Get List of Payments *************************************************************************
        //  GET: api/Payments
        [Route("api/payments")]
        public IQueryable<Payment> GetCarhires()
        {
            return dbPayment.Payments;
        }

        //*******************************************Post Payment *************************************************************************
        // POST: api/Payments
        [Route("api/payments")]
        [ResponseType(typeof(Payment))]
        public IHttpActionResult PostPayment(Payment payment)
        {
            Random rnd = new Random();
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
                MemberDiscount mPay = new MemberDiscount()
                {
                    DiscountRef = CurrentUser + payment.PaymentId.ToString(),
                    MembersEmail = CurrentUser,
                    TransnDate = DateTime.Now,
                    discount = rnd.Next(7),
                    kululaPoints = rnd.Next(15),
                    PaymentId = payment.PaymentId
                };

                dbPayment.MemberDiscounts.Add(mPay);
                dbPayment.SaveChanges();
            }
            return Ok();
        }
        //*******************************************Get Member Discount *************************************************************************
        [Route("api/MemberDiscounts/{id}")]
        [ResponseType(typeof(MemberDiscount))]
        public IHttpActionResult GetMemberDiscount(string id)
        {
            int MaxRow = dbPayment.MemberDiscounts.Count() - 1;
            List<MemberDiscount> allMemberPayments = new List<MemberDiscount>();
            allMemberPayments = dbPayment.MemberDiscounts.ToList();
            MemberDiscount currentMemberPayment = allMemberPayments.ElementAtOrDefault(MaxRow);

            if (currentMemberPayment == null)
            {
                return NotFound();
            }

            return Ok(currentMemberPayment);
        }
        //*******************************************Sent Receipt to email *************************************************************************
        //Get api/Account/VerifyAccount/{id}
        [HttpPost]
        [Authorize]
        [Route("api/payments/receipt/{id}")]
        public IHttpActionResult VerifyAccount(string id)
        {
            string CurrentUser = "Guest";
            if (HttpContext.Current.User.Identity.Name != null) CurrentUser = HttpContext.Current.User.Identity.Name.ToString();
            var httpReququest = HttpContext.Current.Request;
            HtmlElement n = new HtmlElement();
            var file = httpReququest.Files["tickedImg"];
            var file2 = httpReququest["tickedImg"];
            n.InnerHtml = file2;
            if(CurrentUser!= "Guest" && CurrentUser !=null)
            SendTicked(CurrentUser, n);
            return Ok();
        }

        [NonAction]
        public void SendTicked(string emailID, HtmlElement Ticked)
        {
            var fromEmail = new MailAddress("successngw@gmail.com", "Kulula Dotnet Payment");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "Makgate19";
            Ticked.InnerHtml.Clone();
            string subject = "kulula Payment was succesfully !";
            string body = "<br/><br/>Your kulula payment is " + "Success. Please view your ticked below" +
                         "<br/><br/>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
         
            Document document = GeneratePdf.CreateDocument();

          

            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = document;

            renderer.RenderDocument();
            //==
            MemoryStream ms = new MemoryStream();

                renderer.Save(ms, false);
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Flush();
                ms.Read(buffer, 0, (int)ms.Length);
                renderer.PdfDocument.Close();
           
                
               // document.Close();
            
            ContentType ct = new ContentType(MediaTypeNames.Application.Pdf);
            //MyMessage.Attachments.Add(new Attachment(ms, ct));
            //MyMessage.Attachments.Add(new Attachment(ms, "HUDInstructions.pdf", "application/pdf"));
           // Stream stream = new MemoryStream(pdfBuffer);


            //mail.Attachments.Add(attachment);
            var message = new MailMessage(fromEmail, toEmail);

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Attachments.Add(new Attachment(ms, ct));
            smtp.Send(message);
        }
        //*******************************************Current FlightBook *************************************************************************
        private FlightBook currentFlightbook()
        {
            int MaxRow = dbPayment.Carhires.Count() - 1;
            List<FlightBook> allCarhires = new List<FlightBook>();
            allCarhires = dbPayment.FlightBooks.ToList();
            FlightBook currentCarhire = new FlightBook();
            currentCarhire = allCarhires.ElementAtOrDefault(MaxRow);

            return currentCarhire;
        }
        //*******************************************Current Carhire *************************************************************************
        private Carhire currentCarhire()
        {
            int MaxRow = dbPayment.Carhires.Count() - 1;
            List<Carhire> allCarhires = new List<Carhire>();
            allCarhires = dbPayment.Carhires.ToList();
            Carhire currentCarhire = new Carhire();
            currentCarhire= allCarhires.ElementAtOrDefault(MaxRow);

            return currentCarhire;
        }

        //*******************************************Current Seatbook*************************************************************************
        private SeatBooking currentSeatbook()
        {
            int MaxRow = dbPayment.SeatBookings.Count() - 1;
            List<SeatBooking> allSeatbooks = new List<SeatBooking>();
            allSeatbooks = dbPayment.SeatBookings.ToList();
            SeatBooking currentSeatbook = new SeatBooking();
            currentSeatbook= allSeatbooks.ElementAtOrDefault(MaxRow);

            return currentSeatbook;
        }
        private bool PaymentExists(int id)
        {
            return dbPayment.Payments.Count(e => e.PaymentId == id) > 0;
        }
    }
}