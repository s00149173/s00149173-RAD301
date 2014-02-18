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
                t.name = "first trip";
                t.startDate = new DateTime(2013, 02, 10);
                t.endDate = new DateTime(2013, 04, 10);
                t.minimumguestN = 5;
                t.legs = new List<Leg>();

                Leg l = new Leg();
                l.startDate = new DateTime(2013, 02, 10);
                l.endDate = new DateTime(2013, 03, 10);
                l.startLocation = "Porto";
                l.endLocation = "Paris";
                l.guests = new List<string>();
                l.guests.Add("Invited1");
                l.guests.Add("Invited2");
                l.guests.Add("Invited3");
                t.legs.Add(l);

                Leg l1 = new Leg();
                l1.startDate = new DateTime(2013, 03, 10);
                l1.endDate = new DateTime(2013, 04, 10);
                l1.startLocation = "Paris";
                l1.endLocation = "Ibiza";
                l1.guests = new List<string>();
                l1.guests.Add("Invited4");
                l1.guests.Add("Invited5");
                l1.guests.Add("Invited6");
                t.legs.Add(l1);

                db.Trips.Add(t);
                db.Legs.Add(l);
                db.Legs.Add(l1);

                db.SaveChanges();   // Commit changes to db
            }
        }
    }
}