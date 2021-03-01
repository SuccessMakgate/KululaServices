using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KululaServices.Models
{
    public class FlightBook
    {
        public int FlightBookId { get; set; }
        public string DestPlace { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime returnDate { get; set; }
        public bool IsReturn { get; set; }
        public int NumPeople { get; set; }
        public bool IsScheduleFound { get; set; }
        public string memberIDF { get; set; }
        public int FlightScheduleId { get; set; }//FK
        public virtual ICollection<FlightSchedule> MatchedSchedules { get; set; }

    }
    public class FlightSchedule
    {
        public int FlightScheduleId { get; set; }  //Primary Key
        public DateTime DepartDate { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }

        public virtual ICollection<Aircraft> aircrafts { get; set; }

    }
}
