using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class Leg
    {
        public int LegId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }
        public int TripId { get; set; }
        public virtual ICollection<GuestsOnLegs> guestsOnLegs { get; set; }
        public virtual Trip Trip { get; set; }
    }
}