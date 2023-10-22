using RentalsAPI.Core.Data.Models;

namespace RentalsAPI.Core.Suppliers.SouthRentals
{
    public class SouthRentalsService : ISupplier
    {
        public IEnumerable<RentalOffer> FetchOffers()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync(Constants.Suppliers.SouthRentals.FetchURL);
                    HttpResponseMessage result = responseTask.Result;
                    IEnumerable<RentalOffer>? offers = result.Content.ReadFromJsonAsync<IEnumerable<SouthRentalsOffer>>().Result;
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
