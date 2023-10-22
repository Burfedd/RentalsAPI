using RentalsAPI.Core.Data.Models;
using System.Text.Json.Serialization;

namespace RentalsAPI.Core.Suppliers.NorthernRentals
{
    public class NorthernRentalsOffer : RentalOffer
    {
        [JsonPropertyName("id")]
        public override string? LocalID { get; set; }
        [JsonPropertyName("currency")]
        public override string? Currency { get; set; }
        [JsonPropertyName("price")]
        public override double Price { get; set; }
        [JsonPropertyName("vehicleName")]
        public override string? VehicleName { get; set; }
        [JsonPropertyName("sippCode")]
        public override string? SippAcriss { get; set; }
        [JsonPropertyName("image")]
        public override string? ImageURL { get; set; }
        [JsonPropertyName("supplierLogo")]
        public override string? LogoURL { get; set; }
        [JsonIgnore]
        public override string Supplier { get; set; } = "NorthernRentals";
    }
}
