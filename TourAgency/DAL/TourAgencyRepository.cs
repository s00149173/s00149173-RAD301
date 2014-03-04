using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourAgency.DAL;
using TourAgency.Models;

namespace TourAgency.DAL
{
    public class TourAgencyRepository : ITourAgencyRepository
    {
        private TourAgencyContext _ctx;

        public TourAgencyRepository()
        {
            _ctx = new TourAgencyContext();
        }

        public IQueryable<Trip> GetAllTrips()
        {
            return _ctx.Trips;
        }

        public IEnumerable<Leg> GetLegsByTripID(int id)
        {
            return _ctx.Trips.Find(id).Legs;
        }

        public IQueryable<Guest> GetGuestByLegID(int id)
        {
            return _ctx.GuestsOnLegs.Where(g=>g.LegId == id).Select(g=>g.guest);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}