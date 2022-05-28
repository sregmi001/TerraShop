using TerraShop.Domain.Catalog;
using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.Shared;
using TerraShop.Domain.Shipping;
using TerraShop.Domain.ShoppingCart;
using Xunit;

namespace TerraShop.Domain.Tests
{
    public class PriceBasedShippingCalculatorTests
    {
        [Fact]
        public void GivenWhenBasketTotalIsLessThan50ShippingIsQuotedAs10()
        {
            var basket = Basket.Create(VisitorId.NewId());
            basket.AddItem(ProductId.NewId(), new Money { Value = 10 }, 1);

            var priceBasedShippingCalculator = new PriceBasedShippingCalculator(new FakeExchangeRatesProvider());

            var shippingCost = priceBasedShippingCalculator.Quote(basket);

            Assert.Equal(new Money { Value = 10 }, shippingCost);

        }

        [Fact]
        public void GivenWhenBasketTotalIsMoreThan50ShippingIsQuotedAs20()
        {
            var basket = Basket.Create(VisitorId.NewId());
            basket.AddItem(ProductId.NewId(), new Money { Value = 10 }, 1);
            basket.AddItem(ProductId.NewId(), new Money { Value = 25 }, 2);

            var priceBasedShippingCalculator = new PriceBasedShippingCalculator(new FakeExchangeRatesProvider());

            var shippingCost = priceBasedShippingCalculator.Quote(basket);

            Assert.Equal(new Money { Value = 20 }, shippingCost);

        }
    }
}
