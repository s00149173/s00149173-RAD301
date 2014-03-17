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

        [Display(Name = "Start Location"), StringLength(30, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "The Start Location field is required!")]
        public string StartLocation { get; set; }

        [Display(Name = "End Location"), StringLength(30, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "The End Location field is required!")]
        public string EndLocation { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The Start Date field is required!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "The End Date field is required!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Trip")]
        [Required(ErrorMessage = "The Trip field is required!")]
        public int TripId { get; set; }

        public virtual ICollection<GuestsOnLegs> guestsOnLegs { get; set; }
        public virtual Trip Trip { get; set; }
    }
}