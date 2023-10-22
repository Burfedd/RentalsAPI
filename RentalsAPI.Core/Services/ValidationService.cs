namespace RentalsAPI.Core.Services
{
    public class ValidationService : IValidationService
    {
        private static readonly List<string> _validParameters = new List<string>
        {
            "id",
            "currency",
            "price",
            "vehicle",
            "sipp",
            "acriss",
            "supplier"
        };

        public bool IsValidParameter(string parameter)
        {
            return _validParameters.Contains(parameter);
        }
    }
}
