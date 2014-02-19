using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class TourAgencyEntities : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }

        public TourAgencyEntities()
            : base("TourAgencyEntities")
        {
            Database.SetInitializer(new TourAgencyDbSeedDatabase());
        }

        public class TourAgencyDbSeedDatabase : DropCreateDatabaseIfModelChanges<TourAgencyEntities>
        {
            protected override void Seed(TourAgencyEntities db)
            {
                Trip t = new Trip();
                t.Name = "first trip";
                t.StartDate = new DateTime(2013, 02, 10);
                t.EndDate = new DateTime(2013, 04, 10);
                t.MinimumguestN = 5;
                t.Legs = new List<Leg>();

                Leg l = new Leg();
                l.StartDate = new DateTime(2013, 02, 10);
                l.EndDate = new DateTime(2013, 03, 10);
                l.StartLocation = "Porto";
                l.EndLocation = "Paris";
                l.Guests = new List<Guest>();
                Guest g1 = new Guest() { Name = "Antonio Gervasio" };
                Guest g2 = new Guest() { Name = "John Silva" };
                Guest g3 = new Guest() { Name = "Saul The Guy " };
                Guest g4 = new Guest() { Name = "Shanah Gervasio" };
                Guest g5 = new Guest() { Name = "Ana Cruz" };
                l.Guests.Add(g1);
                l.Guests.Add(g2);
                l.Guests.Add(g3);
                l.Guests.Add(g4);
                l.Guests.Add(g5);
                
                t.Legs.Add(l);

                Leg l1 = new Leg();
                l1.StartDate = new DateTime(2013, 03, 10);
                l1.EndDate = new DateTime(2013, 04, 10);
                l1.StartLocation = "Paris";
                l1.StartCountry = "France";
                l1.EndLocation = "Ibiza";
                l1.EndCountry = "Spain";
                l.Guests = new List<Guest>();
                Guest g6 = new Guest() { Name = "Chase Sparling" };
                Guest g7 = new Guest() { Name = "Olga Eein" };
                Guest g8 = new Guest() { Name = "Andrei Seligson " };
                l.Guests.Add(g6);
                l.Guests.Add(g7);
                l.Guests.Add(g8);
                t.Legs.Add(l1);

                db.Trips.Add(t);
                db.Legs.Add(l);
                db.Legs.Add(l1);

                db.SaveChanges();   // Commit changes to db
            }
        }
    }
}