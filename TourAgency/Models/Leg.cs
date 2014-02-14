using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class Leg
    {
        public int LegId { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public virtual ICollection<string> guests { get; set; }
    }
}