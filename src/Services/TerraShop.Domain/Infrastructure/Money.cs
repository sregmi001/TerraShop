namespace TerraShop.Domain.Infrastructure
{
    public record Money
    {
        public static Dictionary<string, decimal> ExchangeRates { get; } = new Dictionary<string, decimal>
        {
            { "AUD", 1m },
            { "NPR", 90m },
            { "NZD", 1.30m }
        };

        public decimal Value { get; set; }
        public decimal BaseCurrencyValue(IExchangeRatesProvider rateProvider)
        {
            if (Currency == BaseCurrency)
            {
                return Value;
            }
            return rateProvider.GetRates()[Currency] / Value;
        }
        public string Currency { get; set; } = BaseCurrency;

        public Money ToCurrency(string currency, IExchangeRatesProvider rateProvider) => new Money
        {
            Currency = currency,
            Value = ExchangeRates[currency] / BaseCurrencyValue(rateProvider),
        };

        public static readonly string BaseCurrency = "AUD";
    }
}
