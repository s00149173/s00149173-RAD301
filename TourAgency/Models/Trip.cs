using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public int MinimumguestN { get; set; }
        public bool Complete { get; set; }
        public bool Viable { get; set; }
        public virtual ICollection<Leg> Legs { get; set; }
    }
}