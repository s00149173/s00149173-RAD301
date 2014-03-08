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

        [Required]
        [Display(Name = "Trip Name"), StringLength(30, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Minimum number of guests"), Range(3, int.MaxValue, ErrorMessage = "Please enter valid integer Number, bigger then 3")]
        public int MinimumguestN { get; set; }
        
        public bool Complete { get; set; }
        public bool Viable { get; set; }
        public virtual ICollection<Leg> Legs { get; set; }
    }
}