using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KululaServices.Models
{
    public class Client
    {

        [Key]
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        

        public List<MemberPayment> Membership { get; set; }

    }
}