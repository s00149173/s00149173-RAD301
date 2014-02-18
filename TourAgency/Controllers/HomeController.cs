using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Models;

namespace TourAgency.Controllers
{
    public class HomeController : Controller
    {
        private TourAgencyEntities db = new TourAgencyEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Trip List Page";

            var trips = db.Trips.ToList();

            return View(trips);
        }

        public ActionResult IndexTrip(int id)
        {
            var selectedTrip = db.Trips.Find(id);

            if (selectedTrip != null)
            {
                if (selectedTrip.legs.Count > 0)
                {
                    var legs = selectedTrip.legs.ToList();
                    return PartialView("_Legs", legs);
                }
                else
                {
                    ViewBag.Message = "No Legs for this Trip";
                }
            }
            ViewBag.Message = "Trip not known";
            return RedirectToAction("Index");
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
    }
}
