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
        public string startLocation { get; set; }
        public string startCountry { get; set; }
        public string endLocation { get; set; }
        public string endCountry { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDate { get; set; }
        public virtual ICollection<string> guests { get; set; }
        public virtual Trip trip { get; set; }
    }
}