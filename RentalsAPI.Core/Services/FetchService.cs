using RentalsAPI.Core.Data.Models;
using RentalsAPI.Core.Data.Repositories;
using RentalsAPI.Core.Suppliers;

namespace RentalsAPI.Core.Services
{
    public class FetchService : IFetchService
    {
        private readonly IEnumerable<ISupplier> _suppliers;
        private readonly IRentalOffersRepository _offersRepository;

        public FetchService(IEnumerable<ISupplier> suppliers, IRentalOffersRepository repository)
        {
            _suppliers = suppliers;
            _offersRepository = repository;
        }
        public async Task RefetchAllSuppliers()
        {
            List<RentalOffer> allOffers = new List<RentalOffer>();
            foreach (ISupplier supplier in _suppliers)
            {
                allOffers.AddRange(supplier.FetchOffers());
            }
            await _offersRepository.ReplaceAll(allOffers);
        }

        public async Task<IEnumerable<RentalOffer>> GetAllOffers(string? orderby = null) {
            return await _offersRepository.GetAll(orderby);
        }
    }
}
