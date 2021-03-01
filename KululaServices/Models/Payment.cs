using KululaServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KululaServices.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string payMethod { get; set; }  // EFT /CreditCard /Cheque /kulula card
        public string AccHolder { get; set; }
        public string AccountNo { get; set; }
        public string CardNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsCarhire { get; set; }
        public bool IsSeatBook { get; set; }

    }
 
    public class MemberDiscount
    {
        [Key]
        public string DiscountRef { get; set; }
        public string MembersEmail { get; set; }
        public DateTime TransnDate { get; set; }
        public double discount { get; set; }
        public int kululaPoints { get; set; }
        public int PaymentId { get; set; }//Fk

    }
}

