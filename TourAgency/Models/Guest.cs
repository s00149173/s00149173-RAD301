using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class Guest
    {
        public int  GuestId {get; set;}
        [Required]
        [Display(Name = "Guest Name")]
        public string Name { get; set; }
        public virtual ICollection<GuestsOnLegs> guestsOnLegs { get; set; }
    }
}