using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Suppliers
{
    public interface ISupplier
    {
        IEnumerable<RentalOffer> FetchOffers();
    }
}
