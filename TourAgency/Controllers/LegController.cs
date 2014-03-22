using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Models;
using TourAgency.DAL;

namespace TourAgency.Controllers
{
    public class LegController : Controller
    {
        private ITourAgencyRepository _repo;

        public LegController(ITourAgencyRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuestList(int id)
        {
            ViewBag.Guests = _repo.AllGuestsList();
            
            ViewBag.ExistingGuest = new GuestsOnLegs {LegId = id};
            var guests = _repo.GetGuestOnLegsByLegID(id);
            return View("_Guests", guests);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Trips = _repo.GetAllTrips().Select(t => new { id = t.TripId, name = t.Name });
            return View();
        }

        [HttpPost]
        public ActionResult Create(Leg leg)
        {
            if (ModelState.IsValid)
            {
                if (LegFitsOnTrip(leg))
                {
                    if (LegDontClash(leg))
                    {
                        _repo.InsertLeg(leg);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Leg dates clash with another leg on this trip";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Leg dates doesn't fit on this trip!";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "";
            }

            ViewBag.Trips = _repo.GetAllTrips().Select(t => new { id = t.TripId, name = t.Name });
            return View(leg);
        }

        private bool LegFitsOnTrip(Leg leg)
        {
            var trip = _repo.GetTripByID(leg.TripId);
            //if leg starts before the trip starts, it fails
            if (trip.StartDate > leg.StartDate)
                return false;

            //if leg ends after the trip ends, it fails
            if (trip.EndDate < leg.EndDate)
                return false;

            return true;
        }

        private bool LegDontClash(Leg leg)
        {

            var legsOfTrip = _repo.GetLegsByTripID(leg.TripId).ToList();

            //if trip does not have any legs it fits
            if (!legsOfTrip.Any())
                return true;

            //if new leg ends before the first starts, it fits
            if (leg.EndDate < legsOfTrip.First().StartDate)
                return true;
            //if new leg starts after the last ends, it fits
            if (leg.StartDate > legsOfTrip.Last().EndDate)
                return true;

  
            bool valid = true;
            bool verifyNext = false;
            while (valid)
            {
                foreach (var item in legsOfTrip)
                {
                    //***method that test the explantion on the buttom****
                    //(continuation of the explination on the button)
                    //so, if the new leg starts before the leg(item) seletec starts
                    //verify if the new leg ends before the next leg starts
                    if (verifyNext)
                        if (leg.StartDate < item.StartDate)
                        {
                            if (leg.EndDate > item.StartDate)
                            {
                                valid = false;
                                break;
                            }
                            else
                            {
                                verifyNext = false;
                            }
                        }
                        else
                        {
                            verifyNext = false;
                        }

                    //if new leg starts or ends on the same day of another legs, it fails
                    if (leg.StartDate.Equals(item.StartDate))
                    {
                        valid = false;
                        break;
                    }
                    if (leg.EndDate.Equals(item.EndDate))
                    {
                        valid = false;
                        break;
                    }

                    //if new leg dates are in the midle of another existing leg, it fails
                    if (leg.StartDate > item.StartDate && leg.EndDate < item.EndDate)
                    {
                        valid = false;
                        break;
                    }

                    //if new leg starts after this(item) leg ends and
                    //this leg(item) is not the last, need to verify if new leg is
                    //between this leg(item) and the next leg(item),
                    //****method on the top of forearch loop****

                    if (leg.StartDate > item.EndDate)
                    {
                        if (item != legsOfTrip.Last())
                        {
                            verifyNext = true;
                        }
                    }
                    if (item == legsOfTrip.Last())
                        return true;
                }
            }
            return valid;
        }

    }
}
