using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
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
            trips = _repo.GetAllTrips().ToList();
            //ViewBag.percentages = CalculatePercentages(trips);
            //List<List<TripStatus>> per = CalculatePercentages(trips);
            //per.First().Where(l=>l.tripId=)
            ViewBag.tripId = 1;
            
        return View(trips);
        }

        public ActionResult Progressbar(int tripId)
        {
            var trip = _repo.GetTripByID(tripId);
            int totalTripDays = (trip.EndDate - trip.StartDate).Days + 1;
            List<TripStatus> statuses = CalcPercentagesTrip(totalTripDays, trip);
            return PartialView("Progressbar",statuses);
        }

        private void CheckIfTripIsViable(int tripId)
        {
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
                    if (legs.Count == 0)
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

        //private List<List<TripStatus>> CalculatePercentages(List<Trip> trips)
        //{

        //    List<List<TripStatus>> percentages = new List<List<TripStatus>>();
        //    foreach (var trip in trips)
        //    {
        //        int totalTripDays = (trip.EndDate - trip.StartDate).Days + 1;
        //        percentages.Add(CalcPercentagesTrip(totalTripDays, trip));
        //    }
        //    return percentages;
        //}

        private double percentage(int totalDays, int legDays)
        {
            return ((legDays * 100) / totalDays);
        }

        private List<TripStatus> CalcPercentagesTrip(int totalDays, Trip trip)
        {
            var legsOfTrip = _repo.GetLegsByTripID(trip.TripId).OrderBy(l => l.StartDate).ToList();
            List<TripStatus> tripStatus = new List<TripStatus>();

            //if trip does not have any legs it fits
            if (!legsOfTrip.Any())
            {
                tripStatus.Add(new TripStatus { tripId = trip.TripId, isLeg = false, percentage = 100, days = totalDays });
                return tripStatus;
            }

            DateTime date = trip.StartDate;
            while (legsOfTrip.Count > 0)
            {
                var leg = legsOfTrip.First();
                int auxLegDays = 0;

                if (date < leg.StartDate)
                {
                    auxLegDays = (leg.StartDate - date).Days;
                    Leg aux = new Leg{StartDate = date, EndDate = leg.StartDate.AddDays(-1)};
                    tripStatus.Add(new TripStatus { tripId = trip.TripId, isLeg = false, percentage = percentage(totalDays, auxLegDays), days = auxLegDays, leg = aux});
                }
                auxLegDays = (leg.EndDate - leg.StartDate).Days + 1;
                tripStatus.Add(new TripStatus { tripId = trip.TripId, isLeg = true, percentage = percentage(totalDays, auxLegDays), days = auxLegDays, leg = leg, nGuests = leg.guestsOnLegs.Count});
                date = leg.EndDate.AddDays(1);
                legsOfTrip.Remove(leg);
                if (legsOfTrip.Count == 0)
                {
                    if (leg.EndDate != trip.EndDate)
                    {
                        if (leg.EndDate < trip.EndDate)
                        {
                            auxLegDays = (trip.EndDate - leg.EndDate).Days;
                            Leg aux = new Leg { StartDate = leg.EndDate.AddDays(1), EndDate = trip.EndDate };
                            tripStatus.Add(new TripStatus { tripId = trip.TripId, isLeg = false, percentage = percentage(totalDays, auxLegDays), days = auxLegDays, leg = aux });
                        }
                    }
                }

            }

            return tripStatus;
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
