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
        public string StartCountry { get; set; }
        public string EndLocation { get; set; }
        public string EndCountry { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual Trip Trip { get; set; }
    }
}