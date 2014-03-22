using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TourAgency.Models;
using TourAgency.DAL;

namespace TourAgency.Controllers
{
    public class GuestsOnLegsController : Controller
    {
        private ITourAgencyRepository _repo;

        public GuestsOnLegsController(ITourAgencyRepository repo)
        {
            _repo = repo;
        }

        //
        // GET: /GuestsOnLegs/Create

        [HttpGet]
        public ActionResult Create(int legId)
        {
            ViewBag.Guests = _repo.AllGuestsList().ToList();
            GuestsOnLegs g = new GuestsOnLegs { LegId = legId };
            return PartialView("_Create", g);
        }

        //
        // POST: /GuestsOnLegs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuestsOnLegs guestsonlegs)
        {
            _repo.insertGuestOnLeg(guestsonlegs);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreateGuest(int legId)
        {

            ViewBag.LegId = legId;
            return PartialView("_CreateGuest");
        }

        //
        // POST: /GuestsOnLegs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGuest(Guest guest, int legId)
        {
            _repo.insertGuest(guest);
            _repo.insertGuestOnLeg(new GuestsOnLegs { GuestId = guest.GuestId, LegId = legId });
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}