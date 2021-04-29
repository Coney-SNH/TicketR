using Microsoft.EntityFrameworkCore;

namespace Ticketr.Models
{
    public class TicketrContext : DbContext
    {
        public TicketrContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users {get;set;}

        public DbSet<Event> Events {get;set;}

        public DbSet<Series> Series {get;set;}

        public DbSet<Patron> Patrons {get;set;}

        public DbSet<Seat> Seats {get;set;}

        public DbSet<SeriesSeatPatronRel> SeriesSeatPatronRels {get;set;}

        public DbSet<PatronSeriesRel> PatronSeriesRels {get;set;} //Many to many model for patrons and series

        public DbSet<Donation> Donations {get;set;}

        public DbSet<PurchasedTicket> PurchasedTickets {get;set;}
    }
}