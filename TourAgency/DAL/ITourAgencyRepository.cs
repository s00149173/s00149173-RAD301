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
        IQueryable<GuestsOnLegs> GetGuestByLegID(int id);
        
    }
}