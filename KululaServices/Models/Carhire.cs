using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KululaServices.Models
{
    public class Carhire
    {
        public int carHireId { get; set; }
        public string pickUp { get; set; }
        public string DropOff { get; set; }
        public bool IsReturn { get; set; }
        public DateTime PickDate { get; set; }
        public bool PaymentStatus { get; set; }
        public  string memberIDC { get; set; }
        //CarModel Foreign Key
        public string CarName { get; set; }
    }
    public class CarModel
    {
        [Key]
        public string CarName { get; set; }
        public string CarColour { get; set; }
        public string YearModel { get; set; }
        public bool LeatherSeat { get; set; }
        public bool Radio_Cd { get; set; }
        public bool AirBag { get; set; }
        public int price { get; set; }
        public string carImage { get; set; }



        public List<Carhire> Cars { get; set; } //one CarHire can have multible of Cars
    }
}