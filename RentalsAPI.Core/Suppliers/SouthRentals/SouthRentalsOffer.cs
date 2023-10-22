using RentalsAPI.Core.Data.Models;
using System.Text.Json.Serialization;

namespace RentalsAPI.Core.Suppliers.SouthRentals
{
    public class SouthRentalsOffer : RentalOffer
    {
        [JsonPropertyName("quoteNumber")]
        public override string? LocalID { get; set; }
        [JsonPropertyName("currency")]
        public override string? Currency { get; set; }
        [JsonPropertyName("price")]
        public override double Price { get; set; }
        [JsonPropertyName("vehicleName")]
        public override string? VehicleName { get; set; }
        [JsonPropertyName("acrissCode")]
        public override string? SippAcriss { get; set; }
        [JsonPropertyName("imageLink")]
        public override string? ImageURL { get; set; }
        [JsonPropertyName("logoLink")]
        public override string? LogoURL { get; set; }
        [JsonIgnore]
        public override string Supplier { get; set; } = "SouthRentals";
    }
}
