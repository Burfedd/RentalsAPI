using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentalsAPI.Core.Data.Models;
using RentalsAPI.Core.Services;

namespace RentalsAPI.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IFetchService _fetchService;
        private readonly IMemoryCache _cache;
        private readonly IValidationService _validationService;

        public RentalsController(IFetchService fetchService, IMemoryCache cache, IValidationService validationService)
        {
            _fetchService = fetchService;
            _cache = cache;
            _validationService = validationService;
        }

        /// <summary>
        /// An API GET endpoint to aggregate multiple car rentals suppliers and present the resulting list in an ordered fashion
        /// </summary>
        /// <param name="orderby">Optional parameter to order the list by. Possible values: "id", "currency", "price", "vehicle", "sipp", "acriss", "supplier"</param>
        /// <returns>An ordered list of car rental offers</returns>
        [HttpGet]
        public async Task<IEnumerable<RentalOffer>> Get([FromQuery]string? orderby = "")
        {
            IEnumerable<RentalOffer>? offers;
            if (orderby != null && _validationService.IsValidParameter(orderby))
            {
                string searchKey = Constants.Cache.Key + orderby;
                if (_cache.TryGetValue(searchKey, out offers))
                {
                    return offers ?? Enumerable.Empty<RentalOffer>();
                }
                await _fetchService.RefetchAllSuppliers();
                offers = await _fetchService.GetAllOffers(orderby);
                _cache.Set(searchKey, offers, TimeSpan.FromMinutes(30));
                return offers;
            }
            else
            {
                if (_cache.TryGetValue(Constants.Cache.Key, out offers))
                {
                    return offers ?? Enumerable.Empty<RentalOffer>(); ;
                }
                await _fetchService.RefetchAllSuppliers();
                offers = await _fetchService.GetAllOffers();
                _cache.Set(Constants.Cache.Key, offers, TimeSpan.FromMinutes(30));
                return offers;
            }
        }
    }
}
