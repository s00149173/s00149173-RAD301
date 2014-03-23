using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class TripStatus
    {
        public int tripId { get; set; }
        public double percentage { get; set; }
        public int days { get; set; }
        public bool isLeg { get; set; }
        public int nGuests { get; set; }
        public Leg leg { get; set; }
    
    }
}