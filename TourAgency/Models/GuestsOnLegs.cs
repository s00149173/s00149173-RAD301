using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class GuestsOnLegs
    {
        [Key]
        public int guestOnLegId { get; set; }
        public int LegId { get; set; }
        public int GuestId { get; set; }

        public virtual Leg leg { get; set; }
        public virtual Guest guest { get; set; }
    }
}