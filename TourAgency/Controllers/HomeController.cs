using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.DAL;
using TourAgency.Models;

namespace TourAgency.Controllers
{
    public class HomeController : Controller
    {
        private ITourAgencyRepository _repo;

        public HomeController(ITourAgencyRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Trip List Page";
            var trips = _repo.GetAllTrips().ToList();
            foreach (var trip in trips)
            {
                CheckIfTripIsViable(trip.TripId);
                CheckIfTripIsComplete(trip.TripId);
            }
            return View(_repo.GetAllTrips().ToList());
        }

        private void CheckIfTripIsViable(int tripId)
        {
            bool bla = false;
            int nGuestCount = 0;
            bool viable = false;
            var guests = _repo.GetAllGuestsOnLegsByTripId(tripId).OrderBy(g => g.GuestId);
            foreach (var g in guests)
            {
                List<GuestsOnLegs> guests2 = guests.ToList();
                guests2.Remove(g);
                int timesThisGuest = 1;
                while (guests2.Count > 0 && timesThisGuest != 2)
                {
                    GuestsOnLegs g2 = guests2.First();
                    if (g2.GuestId == g.GuestId)
                        timesThisGuest++;
                    guests2.Remove(g2);
                }
                if (timesThisGuest > 1)
                    nGuestCount++;

                if (tripId == 2)
                    bla = true;

                if (nGuestCount >= 3)
                {
                    viable = true;
                    break;
                }
            }
            _repo.UpdateTripViable(tripId, viable);
        }

        private void CheckIfTripIsComplete(int tripId)
        {
            bool complete = true;
            var trip = _repo.GetTripByID(tripId);
            DateTime start = trip.StartDate;
            var legs = _repo.GetLegsByTripID(tripId).OrderBy(l => l.StartDate).ToList();
            while (start < trip.EndDate && legs.Count > 0)
            {
                Leg l = legs.First();
                if (start == l.StartDate)
                {
                    start = l.EndDate.AddDays(1);
                    legs.Remove(l);
                    if(legs.Count == 0)
                        if (start == trip.EndDate.AddDays(1))
                            break;
                        else
                        {
                            complete = false;
                            break;   
                        }
                }
                else
                {
                    complete = false;
                    break;
                }
            }
            _repo.UpdateTripComplete(tripId, complete);
        }

        public ActionResult LegsList(int id)
        {
            var legs = _repo.GetLegsByTripID(id).ToList();
            return PartialView("_Legs", legs);
        }

        //
        // GET: /Trip/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trip/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                _repo.InsertTrip(trip);
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        ////
        //// GET: /Trip/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Trip trip = _repo.Trips.Find(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trip);
        //}

        ////
        //// GET: /Trip/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Trip trip = db.Trips.Find(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trip);
        //}

        ////
        //// POST: /Trip/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Trip trip)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(trip).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(trip);
        //}

        ////
        //// GET: /Trip/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Trip trip = db.Trips.Find(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trip);
        //}

        ////
        //// POST: /Trip/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Trip trip = db.Trips.Find(id);
        //    db.Trips.Remove(trip);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
