using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Models;

namespace TourAgency.Controllers
{
    public class LegController : Controller
    {
        private TourAgencyEntities db = new TourAgencyEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuestList(int id)
        {
            Leg leg = db.Legs.Where(l => l.LegId == id).Cast<Leg>().First();
            return View("_Guests", leg);
        }

    }
}
