using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Suppliers.BestRentals
{
    public class BestRentalsService : ISupplier
    {
        public IEnumerable<RentalOffer> FetchOffers()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync(Constants.Suppliers.BestRentals.FetchURL);
                    HttpResponseMessage result = responseTask.Result;
                    IEnumerable<RentalOffer>? offers = result.Content.ReadFromJsonAsync<IEnumerable<BestRentalsOffer>>().Result;
                    return offers ?? Enumerable.Empty<RentalOffer>();
                }
                catch
                {
                    return Enumerable.Empty<RentalOffer>();
                }
            }
        }
    }
}
