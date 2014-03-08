using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TourAgency.Models;

namespace TourAgency.DAL
{
    public class TourAgencyContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestsOnLegs> GuestsOnLegs { get; set; }

        public TourAgencyContext()
            : base("TourAgencyDatabase")
        {
            Database.SetInitializer(new TourAgencyInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    public class TourAgencyInitializer : DropCreateDatabaseIfModelChanges<TourAgencyContext>
    {
        protected override void Seed(TourAgencyContext context)
        {
            var trips = new List<Trip>
            {
                new Trip{Name = "Discover Ireland", StartDate = new DateTime(2014,01,06), EndDate = new DateTime(2014,01,17), MinimumguestN = 6},
                new Trip{Name = "Discover England", StartDate = new DateTime(2014,01,20), EndDate = new DateTime(2014,02,02), MinimumguestN = 6},
                new Trip{Name = "Discover France part 1", StartDate = new DateTime(2014,05,19), EndDate = new DateTime(2014,06,16), MinimumguestN = 6},
                new Trip{Name = "Discover Spain part 1", StartDate = new DateTime(2014,06,17), EndDate = new DateTime(2014,06,30), MinimumguestN = 6},
                new Trip{Name = "Tomorrowland Madness 2014", StartDate = new DateTime(2014,07,01), EndDate = new DateTime(2014,08,04), MinimumguestN = 6},
                new Trip{Name = "Discover Portugal", StartDate = new DateTime(2014,08,01), EndDate = new DateTime(2014,09,01), MinimumguestN = 6}
            };
            trips.ForEach(t => context.Trips.Add(t));
            context.SaveChanges();

            var legs = new List<Leg> 
            {
                //trip 1
                new Leg {StartLocation = "Cork", EndLocation="Dublin", StartDate=new DateTime(2014,01,06), EndDate=new DateTime(2014,01,08), TripId=1},
                new Leg {StartLocation = "Dublin", EndLocation="Antrim", StartDate=new DateTime(2014,01,09), EndDate=new DateTime(2014,01,11), TripId=1},
                new Leg {StartLocation = "Antrim", EndLocation="Sligo", StartDate=new DateTime(2014,01,12), EndDate=new DateTime(2014,01,14), TripId=1},
                new Leg {StartLocation = "Antrim", EndLocation="Sligo", StartDate=new DateTime(2014,01,12), EndDate=new DateTime(2014,01,14), TripId=1},
                new Leg {StartLocation = "Sligo", EndLocation="Glaway", StartDate=new DateTime(2014,01,15), EndDate=new DateTime(2014,01,15), TripId=1},
                new Leg {StartLocation = "Galway", EndLocation="Cork", StartDate=new DateTime(2014,01,15), EndDate=new DateTime(2014,01,17), TripId=1},

                //trip 2
                new Leg {StartLocation = "London", EndLocation="Northamptom", StartDate=new DateTime(2014,01,20), EndDate=new DateTime(2014,01,20), TripId=2},
                new Leg {StartLocation = "Northamptom", EndLocation="Nottingham", StartDate=new DateTime(2014,01,21), EndDate=new DateTime(2014,01,21), TripId=2},
                new Leg {StartLocation = "Nottingham", EndLocation="York", StartDate=new DateTime(2014,01,22), EndDate=new DateTime(2014,01,23), TripId=2},
                new Leg {StartLocation = "York", EndLocation="NewCastle", StartDate=new DateTime(2014,01,24), EndDate=new DateTime(2014,01,25), TripId=2},
                new Leg {StartLocation = "NewCastle", EndLocation="Liverpool", StartDate=new DateTime(2014,01,26), EndDate=new DateTime(2014,01,28), TripId=2},
                new Leg {StartLocation = "Liverpool", EndLocation="Bristol", StartDate=new DateTime(2014,01,26), EndDate=new DateTime(2014,01,28), TripId=2},
                new Leg {StartLocation = "Bristol", EndLocation="Stonehenge", StartDate=new DateTime(2014,01,29), EndDate=new DateTime(2014,01,29), TripId=2},
                new Leg {StartLocation = "Stonehenge", EndLocation="Newquay", StartDate=new DateTime(2014,01,30), EndDate=new DateTime(2014,02,02), TripId=2},

                //trip 3
                new Leg {StartLocation = "Bordeaux", EndLocation="Nantes", StartDate=new DateTime(2014,05,19), EndDate=new DateTime(2014,05,20), TripId=3},
                new Leg {StartLocation = "Nantes", EndLocation="Rennes", StartDate=new DateTime(2014,05,21), EndDate=new DateTime(2014,05,21), TripId=3},
                new Leg {StartLocation = "Rennes", EndLocation="Roven", StartDate=new DateTime(2014,05,22), EndDate=new DateTime(2014,05,23), TripId=3},
                new Leg {StartLocation = "Roven", EndLocation="Paris", StartDate=new DateTime(2014,05,24), EndDate=new DateTime(2014,05,26), TripId=3},
                new Leg {StartLocation = "Paris", EndLocation="Reims", StartDate=new DateTime(2014,05,27), EndDate=new DateTime(2014,05,28), TripId=3},
                new Leg {StartLocation = "Reims", EndLocation="Nancy", StartDate=new DateTime(2014,05,29), EndDate=new DateTime(2014,05,30), TripId=3},
                new Leg {StartLocation = "Nancy", EndLocation="Besançon", StartDate=new DateTime(2014,05,31), EndDate=new DateTime(2014,05,01), TripId=3},
                new Leg {StartLocation = "Besançon", EndLocation="Dijon", StartDate=new DateTime(2014,05,02), EndDate=new DateTime(2014,06,03), TripId=3},
                new Leg {StartLocation = "Dijon", EndLocation="Orleans", StartDate=new DateTime(2014,06,16), EndDate=new DateTime(2014,06,16), TripId=3},

                //trip 4
                new Leg {StartLocation = "Santiago", EndLocation="Orense", StartDate=new DateTime(2014,06,17), EndDate=new DateTime(2014,06,18), TripId=4},
                new Leg {StartLocation = "Orense", EndLocation="Valladolid", StartDate=new DateTime(2014,06,19), EndDate=new DateTime(2014,06,20), TripId=4},
                new Leg {StartLocation = "Valladolid", EndLocation="Madrid", StartDate=new DateTime(2014,06,20), EndDate=new DateTime(2014,06,22), TripId=4},
                new Leg {StartLocation = "Madrid", EndLocation="Ciudad Real", StartDate=new DateTime(2014,06,23), EndDate=new DateTime(2014,06,24), TripId=4},
                new Leg {StartLocation = "Ciudad Real", EndLocation="Seville", StartDate=new DateTime(2014,06,25), EndDate=new DateTime(2014,06,26), TripId=4},
                new Leg {StartLocation = "Seville", EndLocation="Algeciras", StartDate=new DateTime(2014,06,27), EndDate=new DateTime(2014,06,28), TripId=4},
                new Leg {StartLocation = "Algeciras", EndLocation="Malaga", StartDate=new DateTime(2014,06,29), EndDate=new DateTime(2014,06,30), TripId=4},

                //trip 5
                new Leg {StartLocation = "Porto", EndLocation="Ibiza", StartDate=new DateTime(2014,07,01), EndDate=new DateTime(2014,07,09), TripId=5},
                new Leg {StartLocation = "Ibiza", EndLocation="Amesterdam", StartDate=new DateTime(2014,07,10), EndDate=new DateTime(2014,07,16), TripId=5},
                new Leg {StartLocation = "Ibiza", EndLocation="Boom", StartDate=new DateTime(2014,07,17), EndDate=new DateTime(2014,07,20), TripId=5},
                new Leg {StartLocation = "Boom", EndLocation="Vienna", StartDate=new DateTime(2014,07,21), EndDate=new DateTime(2014,07,23), TripId=5},
                new Leg {StartLocation = "Vienna", EndLocation="Boom", StartDate=new DateTime(2014,07,24), EndDate=new DateTime(2014,07,27), TripId=5},
                new Leg {StartLocation = "Boom", EndLocation="Ibiza", StartDate=new DateTime(2014,07,28), EndDate=new DateTime(2014,08,04), TripId=5},

                //trip 6
                new Leg {StartLocation = "Braga", EndLocation="Porto", StartDate=new DateTime(2014,08,01), EndDate=new DateTime(2014,08,03), TripId=6},
                new Leg {StartLocation = "Porto", EndLocation="Coimbra", StartDate=new DateTime(2014,08,04), EndDate=new DateTime(2014,08,06), TripId=6},
                new Leg {StartLocation = "Coimbra", EndLocation="Lisbon", StartDate=new DateTime(2014,08,07), EndDate=new DateTime(2014,08,13), TripId=6},
                new Leg {StartLocation = "Lisbon", EndLocation="Setubal", StartDate=new DateTime(2014,08,14), EndDate=new DateTime(2014,08,18), TripId=6},
                new Leg {StartLocation = "Setubal", EndLocation="Beja", StartDate=new DateTime(2014,08,19), EndDate=new DateTime(2014,08,21), TripId=6},
                new Leg {StartLocation = "Beja", EndLocation="Faro", StartDate=new DateTime(2014,08,22), EndDate=new DateTime(2014,09,01), TripId=6}
            };
            legs.ForEach(l => context.Legs.Add(l));
            context.SaveChanges();

            var guests = new List<Guest>
            {
                new Guest{Name="Arthur Yates"},
                new Guest{Name="Carrie Long"},
                new Guest{Name="Kenneth	Mendoza"},
                new Guest{Name="Warren Estrada"},
                new Guest{Name="Kerry Nunez"},
                new Guest{Name="Pablo Wilkerson"},

                new Guest{Name="Brent Potter"},
                new Guest{Name="Kenny Henry"},
                new Guest{Name="Lucia Ford"},
                new Guest{Name="Sammy Lindsey"},
                new Guest{Name="Annette Watts"},
                new Guest{Name="Alberto Harper"},
                new Guest{Name="Nicole Clarke"},
                new Guest{Name="Earnest Duncan"},
                new Guest{Name="Taylor Weaver"},
                new Guest{Name="Josefina Payne"},
                new Guest{Name="Claire Jensen"},

                new Guest{Name="Meredith Fernandez"},
                new Guest{Name="Derrick Roberts"},
                new Guest{Name="Robin Schwartz"},
                new Guest{Name="Stuart Banks"},
                new Guest{Name="Shawn Holland"},

                new Guest{Name="Ashley Webb"},
                new Guest{Name="Lucas Gray"},
                new Guest{Name="Jorge Greer"},
                new Guest{Name="Rudy Richardson"},
                new Guest{Name="Brian Conner"},

                new Guest{Name="Rosa Peters"},
                new Guest{Name="Elsie Barnett"},
                new Guest{Name="Wilma May"},

                new Guest{Name="Helen Maldonado"},
                new Guest{Name="Della Pitt"},
                new Guest{Name="Melanie Pope"},
                new Guest{Name="Johanna Bowers"},
                new Guest{Name="Mable Richardson"},
                new Guest{Name="Jerry Stokes"},
                new Guest{Name="Rogelio Sims"}

            };
            guests.ForEach(g => context.Guests.Add(g));
            context.SaveChanges();

            var guestOnLegs = new List<GuestsOnLegs>
            {
                //trip 1 --> 6 legs
                new GuestsOnLegs{LegId=1, GuestId=1},
                new GuestsOnLegs{LegId=1, GuestId=2},
                new GuestsOnLegs{LegId=1, GuestId=3},
                new GuestsOnLegs{LegId=1, GuestId=4},
                new GuestsOnLegs{LegId=1, GuestId=5},
                new GuestsOnLegs{LegId=1, GuestId=6},
                
                new GuestsOnLegs{LegId=2, GuestId=1},
                new GuestsOnLegs{LegId=2, GuestId=2},
                new GuestsOnLegs{LegId=2, GuestId=3},
                new GuestsOnLegs{LegId=2, GuestId=4},
                new GuestsOnLegs{LegId=2, GuestId=5},
                new GuestsOnLegs{LegId=2, GuestId=6},

                new GuestsOnLegs{LegId=3, GuestId=1},
                new GuestsOnLegs{LegId=3, GuestId=2},
                new GuestsOnLegs{LegId=3, GuestId=3},
                new GuestsOnLegs{LegId=3, GuestId=4},
                new GuestsOnLegs{LegId=3, GuestId=5},
                new GuestsOnLegs{LegId=3, GuestId=6},
                
                new GuestsOnLegs{LegId=4, GuestId=1},
                new GuestsOnLegs{LegId=4, GuestId=2},
                new GuestsOnLegs{LegId=4, GuestId=3},
                new GuestsOnLegs{LegId=4, GuestId=4},
                new GuestsOnLegs{LegId=4, GuestId=5},
                new GuestsOnLegs{LegId=4, GuestId=6},

                new GuestsOnLegs{LegId=5, GuestId=1},
                new GuestsOnLegs{LegId=5, GuestId=2},
                new GuestsOnLegs{LegId=5, GuestId=3},
                new GuestsOnLegs{LegId=5, GuestId=4},
                new GuestsOnLegs{LegId=5, GuestId=5},
                new GuestsOnLegs{LegId=5, GuestId=6},
                
                new GuestsOnLegs{LegId=6, GuestId=1},
                new GuestsOnLegs{LegId=6, GuestId=2},
                new GuestsOnLegs{LegId=6, GuestId=3},
                new GuestsOnLegs{LegId=6, GuestId=4},
                new GuestsOnLegs{LegId=6, GuestId=5},
                new GuestsOnLegs{LegId=6, GuestId=6},

                //trip 2 --> 8 legs
                new GuestsOnLegs{LegId=7, GuestId=7},
                new GuestsOnLegs{LegId=7, GuestId=8},
                new GuestsOnLegs{LegId=7, GuestId=9},
                new GuestsOnLegs{LegId=7, GuestId=10},
                new GuestsOnLegs{LegId=7, GuestId=11},
                new GuestsOnLegs{LegId=7, GuestId=12},
                new GuestsOnLegs{LegId=7, GuestId=13},
                new GuestsOnLegs{LegId=7, GuestId=14},
                new GuestsOnLegs{LegId=7, GuestId=15},
                new GuestsOnLegs{LegId=7, GuestId=16},
                new GuestsOnLegs{LegId=7, GuestId=17},

                new GuestsOnLegs{LegId=8, GuestId=7},
                new GuestsOnLegs{LegId=8, GuestId=8},
                new GuestsOnLegs{LegId=8, GuestId=9},
                new GuestsOnLegs{LegId=8, GuestId=10},
                new GuestsOnLegs{LegId=8, GuestId=11},
                new GuestsOnLegs{LegId=8, GuestId=12},
                new GuestsOnLegs{LegId=8, GuestId=13},
                new GuestsOnLegs{LegId=8, GuestId=14},
                new GuestsOnLegs{LegId=8, GuestId=15},
                new GuestsOnLegs{LegId=8, GuestId=16},
                new GuestsOnLegs{LegId=8, GuestId=17},

                new GuestsOnLegs{LegId=9, GuestId=7},
                new GuestsOnLegs{LegId=9, GuestId=8},
                new GuestsOnLegs{LegId=9, GuestId=9},
                new GuestsOnLegs{LegId=9, GuestId=10},
                new GuestsOnLegs{LegId=9, GuestId=11},
                new GuestsOnLegs{LegId=9, GuestId=12},
                new GuestsOnLegs{LegId=9, GuestId=13},
                new GuestsOnLegs{LegId=9, GuestId=14},
                new GuestsOnLegs{LegId=9, GuestId=15},
                new GuestsOnLegs{LegId=9, GuestId=16},
                new GuestsOnLegs{LegId=9, GuestId=17},

                new GuestsOnLegs{LegId=10, GuestId=7},
                new GuestsOnLegs{LegId=10, GuestId=8},
                new GuestsOnLegs{LegId=10, GuestId=9},
                new GuestsOnLegs{LegId=10, GuestId=10},
                new GuestsOnLegs{LegId=10, GuestId=11},
                new GuestsOnLegs{LegId=10, GuestId=12},
                new GuestsOnLegs{LegId=10, GuestId=13},
                new GuestsOnLegs{LegId=10, GuestId=14},
                new GuestsOnLegs{LegId=10, GuestId=15},
                new GuestsOnLegs{LegId=10, GuestId=16},
                new GuestsOnLegs{LegId=10, GuestId=17},

                new GuestsOnLegs{LegId=11, GuestId=7},
                new GuestsOnLegs{LegId=11, GuestId=8},
                new GuestsOnLegs{LegId=11, GuestId=9},
                new GuestsOnLegs{LegId=11, GuestId=10},
                new GuestsOnLegs{LegId=11, GuestId=11},
                new GuestsOnLegs{LegId=11, GuestId=12},
                new GuestsOnLegs{LegId=11, GuestId=13},
                new GuestsOnLegs{LegId=11, GuestId=14},
                new GuestsOnLegs{LegId=11, GuestId=15},
                new GuestsOnLegs{LegId=11, GuestId=16},
                new GuestsOnLegs{LegId=11, GuestId=17},

                new GuestsOnLegs{LegId=12, GuestId=7},
                new GuestsOnLegs{LegId=12, GuestId=8},
                new GuestsOnLegs{LegId=12, GuestId=9},
                new GuestsOnLegs{LegId=12, GuestId=10},
                new GuestsOnLegs{LegId=12, GuestId=11},
                new GuestsOnLegs{LegId=12, GuestId=12},
                new GuestsOnLegs{LegId=12, GuestId=13},
                new GuestsOnLegs{LegId=12, GuestId=14},
                new GuestsOnLegs{LegId=12, GuestId=15},
                new GuestsOnLegs{LegId=12, GuestId=16},
                new GuestsOnLegs{LegId=12, GuestId=17},

                new GuestsOnLegs{LegId=13, GuestId=7},
                new GuestsOnLegs{LegId=13, GuestId=8},
                new GuestsOnLegs{LegId=13, GuestId=9},
                new GuestsOnLegs{LegId=13, GuestId=10},
                new GuestsOnLegs{LegId=13, GuestId=11},
                new GuestsOnLegs{LegId=13, GuestId=12},
                new GuestsOnLegs{LegId=13, GuestId=13},
                new GuestsOnLegs{LegId=13, GuestId=14},
                new GuestsOnLegs{LegId=13, GuestId=15},
                new GuestsOnLegs{LegId=13, GuestId=16},
                new GuestsOnLegs{LegId=13, GuestId=17},

                new GuestsOnLegs{LegId=14, GuestId=7},
                new GuestsOnLegs{LegId=14, GuestId=8},
                new GuestsOnLegs{LegId=14, GuestId=9},
                new GuestsOnLegs{LegId=14, GuestId=10},
                new GuestsOnLegs{LegId=14, GuestId=11},
                new GuestsOnLegs{LegId=14, GuestId=12},
                new GuestsOnLegs{LegId=14, GuestId=13},
                new GuestsOnLegs{LegId=14, GuestId=14},
                new GuestsOnLegs{LegId=14, GuestId=15},
                new GuestsOnLegs{LegId=14, GuestId=16},
                new GuestsOnLegs{LegId=14, GuestId=17},

                //trip 3 --> 9 legs
                new GuestsOnLegs{LegId=14, GuestId=18},
                new GuestsOnLegs{LegId=14, GuestId=19},
                new GuestsOnLegs{LegId=14, GuestId=20},
                new GuestsOnLegs{LegId=14, GuestId=21},
                new GuestsOnLegs{LegId=14, GuestId=22},

                new GuestsOnLegs{LegId=15, GuestId=18},
                new GuestsOnLegs{LegId=15, GuestId=19},
                new GuestsOnLegs{LegId=15, GuestId=20},
                new GuestsOnLegs{LegId=15, GuestId=21},
                new GuestsOnLegs{LegId=15, GuestId=22},

                new GuestsOnLegs{LegId=16, GuestId=18},
                new GuestsOnLegs{LegId=16, GuestId=19},
                new GuestsOnLegs{LegId=16, GuestId=20},
                new GuestsOnLegs{LegId=16, GuestId=21},
                new GuestsOnLegs{LegId=16, GuestId=22},

                new GuestsOnLegs{LegId=17, GuestId=18},
                new GuestsOnLegs{LegId=17, GuestId=19},
                new GuestsOnLegs{LegId=17, GuestId=20},
                new GuestsOnLegs{LegId=17, GuestId=21},
                new GuestsOnLegs{LegId=17, GuestId=22},

                new GuestsOnLegs{LegId=18, GuestId=18},
                new GuestsOnLegs{LegId=18, GuestId=19},
                new GuestsOnLegs{LegId=18, GuestId=20},
                new GuestsOnLegs{LegId=18, GuestId=21},
                new GuestsOnLegs{LegId=18, GuestId=22},

                new GuestsOnLegs{LegId=19, GuestId=18},
                new GuestsOnLegs{LegId=19, GuestId=19},
                new GuestsOnLegs{LegId=19, GuestId=20},
                new GuestsOnLegs{LegId=19, GuestId=21},
                new GuestsOnLegs{LegId=19, GuestId=22},

                new GuestsOnLegs{LegId=20, GuestId=18},
                new GuestsOnLegs{LegId=20, GuestId=19},
                new GuestsOnLegs{LegId=20, GuestId=20},
                new GuestsOnLegs{LegId=20, GuestId=21},
                new GuestsOnLegs{LegId=20, GuestId=22},

                new GuestsOnLegs{LegId=21, GuestId=18},
                new GuestsOnLegs{LegId=21, GuestId=19},
                new GuestsOnLegs{LegId=21, GuestId=20},
                new GuestsOnLegs{LegId=21, GuestId=21},
                new GuestsOnLegs{LegId=21, GuestId=22},

                new GuestsOnLegs{LegId=22, GuestId=18},
                new GuestsOnLegs{LegId=22, GuestId=19},
                new GuestsOnLegs{LegId=22, GuestId=20},
                new GuestsOnLegs{LegId=22, GuestId=21},
                new GuestsOnLegs{LegId=22, GuestId=22},

                //trip4
                new GuestsOnLegs{LegId=23, GuestId=23},
                new GuestsOnLegs{LegId=23, GuestId=24},
                new GuestsOnLegs{LegId=23, GuestId=25},
                new GuestsOnLegs{LegId=23, GuestId=16},
                new GuestsOnLegs{LegId=23, GuestId=27},
                
                new GuestsOnLegs{LegId=24, GuestId=23},
                new GuestsOnLegs{LegId=24, GuestId=24},
                new GuestsOnLegs{LegId=24, GuestId=25},
                new GuestsOnLegs{LegId=24, GuestId=16},
                new GuestsOnLegs{LegId=24, GuestId=27},

                new GuestsOnLegs{LegId=25, GuestId=23},
                new GuestsOnLegs{LegId=25, GuestId=24},
                new GuestsOnLegs{LegId=25, GuestId=25},
                new GuestsOnLegs{LegId=25, GuestId=16},
                new GuestsOnLegs{LegId=25, GuestId=27},

                new GuestsOnLegs{LegId=26, GuestId=23},
                new GuestsOnLegs{LegId=26, GuestId=24},
                new GuestsOnLegs{LegId=26, GuestId=25},
                new GuestsOnLegs{LegId=26, GuestId=16},
                new GuestsOnLegs{LegId=26, GuestId=27},

                new GuestsOnLegs{LegId=27, GuestId=23},
                new GuestsOnLegs{LegId=27, GuestId=24},
                new GuestsOnLegs{LegId=27, GuestId=25},
                new GuestsOnLegs{LegId=27, GuestId=16},
                new GuestsOnLegs{LegId=27, GuestId=27},

                new GuestsOnLegs{LegId=28, GuestId=23},
                new GuestsOnLegs{LegId=28, GuestId=24},
                new GuestsOnLegs{LegId=28, GuestId=25},
                new GuestsOnLegs{LegId=28, GuestId=16},
                new GuestsOnLegs{LegId=28, GuestId=27},

                new GuestsOnLegs{LegId=29, GuestId=23},
                new GuestsOnLegs{LegId=29, GuestId=24},
                new GuestsOnLegs{LegId=29, GuestId=25},
                new GuestsOnLegs{LegId=29, GuestId=16},
                new GuestsOnLegs{LegId=29, GuestId=27},

                new GuestsOnLegs{LegId=30, GuestId=23},
                new GuestsOnLegs{LegId=30, GuestId=24},
                new GuestsOnLegs{LegId=30, GuestId=25},
                new GuestsOnLegs{LegId=30, GuestId=16},
                new GuestsOnLegs{LegId=30, GuestId=27},
                
                //trip 5
                new GuestsOnLegs{LegId=31, GuestId=28},
                new GuestsOnLegs{LegId=31, GuestId=29},
                new GuestsOnLegs{LegId=31, GuestId=30},
                
                new GuestsOnLegs{LegId=32, GuestId=28},
                new GuestsOnLegs{LegId=32, GuestId=29},
                new GuestsOnLegs{LegId=32, GuestId=30},

                new GuestsOnLegs{LegId=33, GuestId=28},
                new GuestsOnLegs{LegId=33, GuestId=29},
                new GuestsOnLegs{LegId=33, GuestId=30},

                new GuestsOnLegs{LegId=34, GuestId=28},
                new GuestsOnLegs{LegId=34, GuestId=29},
                new GuestsOnLegs{LegId=34, GuestId=30},

                new GuestsOnLegs{LegId=35, GuestId=28},
                new GuestsOnLegs{LegId=35, GuestId=29},
                new GuestsOnLegs{LegId=35, GuestId=30},

                new GuestsOnLegs{LegId=36, GuestId=28},
                new GuestsOnLegs{LegId=36, GuestId=29},
                new GuestsOnLegs{LegId=36, GuestId=30},

                //trip 6
                new GuestsOnLegs{LegId=37, GuestId=31},
                new GuestsOnLegs{LegId=37, GuestId=32},
                new GuestsOnLegs{LegId=37, GuestId=33},
                new GuestsOnLegs{LegId=37, GuestId=34},
                new GuestsOnLegs{LegId=37, GuestId=35},
                new GuestsOnLegs{LegId=37, GuestId=36},
                new GuestsOnLegs{LegId=37, GuestId=37},

                new GuestsOnLegs{LegId=38, GuestId=31},
                new GuestsOnLegs{LegId=38, GuestId=32},
                new GuestsOnLegs{LegId=38, GuestId=33},
                new GuestsOnLegs{LegId=38, GuestId=34},
                new GuestsOnLegs{LegId=38, GuestId=35},
                new GuestsOnLegs{LegId=38, GuestId=36},
                new GuestsOnLegs{LegId=38, GuestId=37},

                new GuestsOnLegs{LegId=39, GuestId=31},
                new GuestsOnLegs{LegId=39, GuestId=32},
                new GuestsOnLegs{LegId=39, GuestId=33},
                new GuestsOnLegs{LegId=39, GuestId=34},
                new GuestsOnLegs{LegId=39, GuestId=35},
                new GuestsOnLegs{LegId=39, GuestId=36},
                new GuestsOnLegs{LegId=39, GuestId=37},

                new GuestsOnLegs{LegId=40, GuestId=31},
                new GuestsOnLegs{LegId=40, GuestId=32},
                new GuestsOnLegs{LegId=40, GuestId=33},
                new GuestsOnLegs{LegId=40, GuestId=34},
                new GuestsOnLegs{LegId=40, GuestId=35},
                new GuestsOnLegs{LegId=40, GuestId=36},
                new GuestsOnLegs{LegId=40, GuestId=37},

                new GuestsOnLegs{LegId=41, GuestId=31},
                new GuestsOnLegs{LegId=41, GuestId=32},
                new GuestsOnLegs{LegId=41, GuestId=33},
                new GuestsOnLegs{LegId=41, GuestId=34},
                new GuestsOnLegs{LegId=41, GuestId=35},
                new GuestsOnLegs{LegId=41, GuestId=36},
                new GuestsOnLegs{LegId=41, GuestId=37},

                new GuestsOnLegs{LegId=42, GuestId=31},
                new GuestsOnLegs{LegId=42, GuestId=32},
                new GuestsOnLegs{LegId=42, GuestId=33},
                new GuestsOnLegs{LegId=42, GuestId=34},
                new GuestsOnLegs{LegId=42, GuestId=35},
                new GuestsOnLegs{LegId=42, GuestId=36},
                new GuestsOnLegs{LegId=42, GuestId=37}

            };

            guestOnLegs.ForEach(g => context.GuestsOnLegs.Add(g));
            context.SaveChanges();
           
        }
    }
}
