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
            var guests = _repo.GetGuestOnLegsByLegID(id);
            return View("_Guests", guests);
        }

    }
}
