using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KululaServices.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; }  //Primary Key
        public string AircraftNo { get; set; }
        public string AircraftName { get; set; }
        public int MaxSeats { get; set; }  //Number of seat of Aircraft
        public int NumSeatBooked { get; set; }//get it with metadata
        public string AircraftLogo { get; set; }
        public bool IsFlightFull { get; set; }
        public int price { get; set; }
    }
    public class SeatBooking
    {
        public int SeatBookingId { get; set; }  //Primary Key
        public int SeatNumber { get; set; } //From Aircfrat MaxSeat
        public int SeatPrice { get; set; }
        public string SeatName { get; set; }
        public bool PaymentStatus { get; set; }


        public int AircraftId { get; set; }  //Foreign Key
        public Aircraft AircraftSeat { get; set; } //Get Aircraft Method
    }
    public class FlightExtra
    {
        public int FlightExtraId { get; set; }
        public bool InlPets { get; set; }
        public bool InlInsurance { get; set; }
        public bool InlMeal { get; set; }
        public double ExPrice { get; set; }

        public int SeatBookingId { get; set; }  //Foreign Key
    }
    public class Traveller
    {
        public int TravellerId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public int SeatBookingId { get; set; }  //Foreign Key
    }
}