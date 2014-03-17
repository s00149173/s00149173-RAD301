using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourAgency.Models;

namespace TourAgency.DAL
{
    public interface ITourAgencyRepository:IDisposable
    {
        IQueryable<Trip> GetAllTrips();
        IQueryable<Leg> GetLegsByTripID(int id);
        IQueryable<GuestsOnLegs> GetGuestOnLegsByLegID(int id);
        IQueryable<Guest> GetGuestByLegID(int id);
        Trip GetTripByID(int id);
        void InsertTrip(Trip trip);
        void InsertLeg(Leg leg);

    }
}