namespace TerraShop.Domain.Infrastructure
{
    public interface IExchangeRatesProvider
    {
        Dictionary<string, decimal> GetRates();
    }
}
