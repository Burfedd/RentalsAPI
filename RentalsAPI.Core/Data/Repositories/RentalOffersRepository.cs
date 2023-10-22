using Microsoft.EntityFrameworkCore;
using RentalsAPI.Core.Data.Context;
using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Data.Repositories
{
    public class RentalOffersRepository : IRentalOffersRepository
    {
        private readonly RentalsContext _context;

        public RentalOffersRepository(RentalsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalOffer>> GetAll(string? orderby = null)
        {
            switch (orderby)
            {
                case "id":
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.GlobalID)
                        .ToListAsync();
                    };
                case "currency":
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.Currency)
                        .ToListAsync();
                    };
                case "price":
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.Price)
                        .ToListAsync();
                    };
                case "vehicle":
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.VehicleName)
                        .ToListAsync();
                    };
                case "sipp" or "acriss":
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.SippAcriss)
                        .ToListAsync();
                    };
                case "supplier":
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.Supplier)
                        .ToListAsync();
                    };
                case null:
                default:
                    {
                        return await _context.RentalOffers
                        .OrderBy(offer => offer.Price)
                        .ThenBy(offer => offer.Supplier)
                        .ToListAsync();
                    };
            }
        }

        public async Task ReplaceAll(IEnumerable<RentalOffer> offers)
        {
            _context.RentalOffers.RemoveRange(_context.RentalOffers);
            await _context.RentalOffers.AddRangeAsync(offers);
            await _context.SaveChangesAsync();
        }
    }
}
