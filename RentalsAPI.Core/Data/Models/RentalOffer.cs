using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsAPI.Core.Data.Models
{
    public abstract class RentalOffer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GlobalID { get; set; }
        public abstract string? LocalID { get; set; }
        public abstract string? Currency { get; set; }
        public abstract double Price { get; set; }
        public abstract string? VehicleName { get; set; }
        public abstract string? SippAcriss { get; set; }
        public abstract string? ImageURL { get; set; }
        public abstract string? LogoURL { get; set; }
        public abstract string Supplier { get; set; }
    }
}