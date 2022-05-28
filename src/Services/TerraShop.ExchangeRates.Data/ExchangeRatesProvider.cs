using TerraShop.Domain.Infrastructure;

namespace TerraShop.ExchangeRates.Data
{
    public class ExchangeRatesProvider : IExchangeRatesProvider
    {
        private static Dictionary<string, decimal> ExchangeRates { get; } = new Dictionary<string, decimal>
        {
            { "AUD", 1m },
            { "NPR", 90m },
            { "NZD", 1.30m }
        };

        public Dictionary<string, decimal> GetRates() => ExchangeRates;
    }
}
