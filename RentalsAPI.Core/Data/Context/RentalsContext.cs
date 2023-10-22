using Microsoft.EntityFrameworkCore;
using RentalsAPI.Core.Data.Models;
using RentalsAPI.Core.Suppliers.BestRentals;
using RentalsAPI.Core.Suppliers.NorthernRentals;
using RentalsAPI.Core.Suppliers.SouthRentals;

namespace RentalsAPI.Core.Data.Context
{
    public class RentalsContext : DbContext
    {
        public RentalsContext(DbContextOptions options) : base(options) { }
        public DbSet<RentalOffer> RentalOffers { get; set; }
        public DbSet<BestRentalsOffer> BestRentalsOffers { get; set; }
        public DbSet<NorthernRentalsOffer> NorthernRentalsOffers { get; set; }
        public DbSet<SouthRentalsOffer> SouthRentalsOffers { get; set; }
    }
}
