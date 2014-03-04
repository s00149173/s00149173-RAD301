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
            return View(trips);
        }

        public ActionResult LegsList(int id)
        {
            var legs = _repo.GetLegsByTripID(id);
            return PartialView("_Legs", legs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
