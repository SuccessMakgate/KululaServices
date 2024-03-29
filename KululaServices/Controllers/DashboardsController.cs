﻿using KululaServices.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KululaServices.Controllers
{
    [Authorize]
    [RoutePrefix("api/dashboards")]
    public class DashboardsController : ApiController
    {
        private kululaContext db = new kululaContext();

        // GET: api/dashboards/id/discount
        [Route("{id}/discount")]
        [ResponseType(typeof(MemberDiscount))]
        public IHttpActionResult GetMemberDiscount(string id)
        {

            List<MemberDiscount> allMemberPayments = new List<MemberDiscount>();
            allMemberPayments = db.MemberDiscounts.Where(d => d.MembersEmail == id).ToList();

            if (allMemberPayments.Count == 0)
            {
                return NotFound();
            }

            return Ok(allMemberPayments);
        }

        // Get: api/dashboards/id/flightbook
        [Route("{id}/flightbook")]
        [HttpGet]
        [ResponseType(typeof(FlightBook))]
        public IHttpActionResult SearchFlight(string id)
        {
            List<FlightBook> flightbookHistory = new List<FlightBook>();
            flightbookHistory = db.FlightBooks.Where(d => d.memberIDF == id).ToList();

            if (flightbookHistory.Count == 0)
            {
                return NotFound();
            }

            return Ok(flightbookHistory);
        }

        // GET: api/dashboards/id/carhire
        [Route("{id}/carhire")]
        [ResponseType(typeof(Carhire))]
        public IHttpActionResult GetCarhire(string id)
        {
            List<Carhire> carhirehistory = new List<Carhire>();
            carhirehistory = db.Carhires.Where(a => a.memberIDC == id).ToList();
            if (carhirehistory.Count == 0)
            {
                return NotFound();
            }

            return Ok(carhirehistory);
        }

    }
}
