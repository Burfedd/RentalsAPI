using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Services
{
    public interface IFetchService
    {
        Task RefetchAllSuppliers();
        Task<IEnumerable<RentalOffer>> GetAllOffers(string? orderby = null);
    }
}
