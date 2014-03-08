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

        public IQueryable<Leg> GetLegsByTripID(int id)
        {
            return _ctx.Legs.Where(shit => shit.TripId == id);
        }

        public IQueryable<GuestsOnLegs> GetGuestByLegID(int id)
        {
            var guests = _ctx.GuestsOnLegs.Where(g=>g.LegId == id);
            return guests;
        }

        public bool InsertTrip(Trip trip)
        {
            bool result = false;
            if (trip != null)
            {
                _ctx.Trips.Add(trip);
                _ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}