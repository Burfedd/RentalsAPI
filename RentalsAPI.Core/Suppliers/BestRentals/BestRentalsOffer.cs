using RentalsAPI.Core.Data.Models;
using System.Text.Json.Serialization;

namespace RentalsAPI.Core.Suppliers.BestRentals
{
    public class BestRentalsOffer : RentalOffer
    {
        [JsonPropertyName("uniqueId")]
        public override string? LocalID { get; set; }
        [JsonPropertyName("rentalCostCurrency")]
        public override string? Currency { get; set; }
        [JsonPropertyName("rentalCost")]
        public override double Price { get; set; }
        [JsonPropertyName("vehicle")]
        public override string? VehicleName { get; set; }
        [JsonPropertyName("sipp")]
        public override string? SippAcriss { get; set; }
        [JsonPropertyName("imageLink")]
        public override string? ImageURL { get; set; }
        [JsonPropertyName("logo")]
        public override string? LogoURL { get; set; }
        [JsonIgnore]
        public override string Supplier { get; set; } = "BestRentals";
    }
}
