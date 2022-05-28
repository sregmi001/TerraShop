using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.Domain.Shipping
{
    public class PriceBasedShippingCalculator : IShippingStrategy
    {
        private readonly IExchangeRatesProvider _exchangeRatesProvider;

        public PriceBasedShippingCalculator(IExchangeRatesProvider exchangeRatesProvider)
        {
            _exchangeRatesProvider = exchangeRatesProvider;
        }

        public Money Quote(Basket basket)
        {
            return basket.TotalExShipping(_exchangeRatesProvider).Value > 50m
                ? new Money { Value = 20 }
                : new Money { Value = 10 };
        }
    }
}
