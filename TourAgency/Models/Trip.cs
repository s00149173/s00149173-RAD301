using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public virtual ICollection<Leg> legs { get; set; }
        public int minimumguestN { get; set; }
        public bool complete { get; set; }
        public bool viable { get; set; }

    }
}