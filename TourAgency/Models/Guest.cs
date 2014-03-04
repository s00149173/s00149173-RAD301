using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class Guest
    {
        public int  GuestId {get; set;}
        public string Name { get; set; }
        public virtual ICollection<GuestsOnLegs> guestsOnLegs { get; set; }
    }
}