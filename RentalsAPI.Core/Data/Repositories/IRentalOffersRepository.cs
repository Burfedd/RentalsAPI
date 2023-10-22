using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Data.Repositories
{
    public interface IRentalOffersRepository
    {
        Task<IEnumerable<RentalOffer>> GetAll(string? orderby);
        Task ReplaceAll(IEnumerable<RentalOffer> offers);
    }
}
