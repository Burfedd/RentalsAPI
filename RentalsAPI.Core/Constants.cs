namespace RentalsAPI.Core
{
    public struct Constants
    {
        public struct Cache
        {
            public const string Key = "RentalOffers";
        }
        public struct Suppliers
        {
            public struct BestRentals
            {
                public const string FetchURL = "https://suppliers-test.dev-dch.com/api/v1/BestRentals/AvailableOffers";
            }

            public struct NorthernRentals
            {
                public const string FetchURL = "https://suppliers-test.dev-dch.com/api/v1/NorthernRentals/GetRates";
            }

            public struct SouthRentals
            {
                public const string FetchURL = "https://suppliers-test.dev-dch.com/api/v1/SouthRentals/Quotes";
            }
        }
    }
}
