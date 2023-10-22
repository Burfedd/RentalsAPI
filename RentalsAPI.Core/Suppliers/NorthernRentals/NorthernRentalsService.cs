using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Suppliers.NorthernRentals
{
    public class NorthernRentalsService : ISupplier
    {
        public IEnumerable<RentalOffer> FetchOffers()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync(Constants.Suppliers.NorthernRentals.FetchURL);
                    HttpResponseMessage result = responseTask.Result;
                    IEnumerable<RentalOffer>? offers = result.Content.ReadFromJsonAsync<IEnumerable<NorthernRentalsOffer>>().Result;
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
