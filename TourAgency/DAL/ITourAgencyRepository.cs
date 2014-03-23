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
        IQueryable<Leg> GetLegsByGuestID(int id);
        List<GuestsOnLegs> GetAllGuestsOnLegsByTripId(int id);
        IQueryable<Guest> AllGuestsList();
        void UpdateTripViable(int tripId, bool viable);
        void UpdateTripComplete(int tripId, bool complete);

        Trip GetTripByID(int id);
        void InsertTrip(Trip trip);
        void InsertLeg(Leg leg);
        void insertGuestOnLeg(GuestsOnLegs g);
        void insertGuest(Guest g);

    }
}