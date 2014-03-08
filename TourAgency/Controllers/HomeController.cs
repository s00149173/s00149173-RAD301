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
            return View(_repo.GetAllTrips().ToList());
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
                //if (_repo.InsertTrip(trip))
                //{

                //}
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
