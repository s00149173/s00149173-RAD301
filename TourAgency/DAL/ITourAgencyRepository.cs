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
        IEnumerable<Leg> GetLegsByTripID(int id);
        IQueryable<Guest> GetGuestByLegID(int id);
        
    }
}