using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Ninject.Infrastructure.Language;
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
            return _ctx.Legs.Where(s => s.TripId == id);
        }


        public IQueryable<GuestsOnLegs> GetGuestOnLegsByLegID(int id)
        {
            var guests = _ctx.GuestsOnLegs.Where(l => l.LegId == id);

            return guests;
        }

        public IQueryable<Guest> GetGuestByLegID(int id)
        {
            var guests = _ctx.GuestsOnLegs.Where(l => l.LegId == id).Select(g => g.guest);

            return guests;
        }

        public IQueryable<Leg> GetLegsByGuestID(int id)
        {
            var legs = _ctx.GuestsOnLegs.Where(g => g.GuestId == id).Select(l => l.leg);

            return legs;
        }

        public List<GuestsOnLegs> GetAllGuestsOnLegsByTripId(int id)
        {
            var legs = GetLegsByTripID(id);
            List<GuestsOnLegs> guests = new List<GuestsOnLegs>();
            foreach (var leg in legs)
            {
                foreach (var g in leg.guestsOnLegs)
                {
                    guests.Add(g);
                }
            }
            return guests;
        }



        public void UpdateTripViable(int tripId, bool viable)
        {
            var trip = GetTripByID(tripId);
            trip.Viable = viable;
            _ctx.Trips.Attach(trip);
            _ctx.Entry(trip).State = EntityState.Modified;
            _ctx.SaveChanges();

        }

        public void UpdateTripComplete(int tripId, bool complete)
        {
            var trip = GetTripByID(tripId);
            trip.Complete = complete;
            _ctx.Trips.Attach(trip);
            _ctx.Entry(trip).State = EntityState.Modified;
            _ctx.SaveChanges();
        }


        public void InsertTrip(Trip trip)
        {
            _ctx.Trips.Add(trip);
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }


        public void InsertLeg(Leg leg)
        {
            _ctx.Legs.Add(leg);
            _ctx.SaveChanges();
        }


        public Trip GetTripByID(int id)
        {
            return _ctx.Trips.Find(id);
        }

        
        public IQueryable<Guest> AllGuestsList()
        {
            return _ctx.Guests;
        }


        public void insertGuestOnLeg(GuestsOnLegs g)
        {
            _ctx.GuestsOnLegs.Add(g);
            _ctx.SaveChanges();
        }


        public void insertGuest(Guest g)
        {
            _ctx.Guests.Add(g);
            _ctx.SaveChanges();
        }
    }
}