using TerraShop.Domain.Infrastructure;
using Xunit;

namespace TerraShop.Domain.Tests
{
    public class MoneyTests
    {
        [Theory]
        [InlineData("AUD", 1, "NZD", 1.30)]
        [InlineData("AUD", 1, "NPR", 90)]
        [InlineData("NPR", 90, "NZD", 1.30)]
        [InlineData("NPR", 180, "AUD", 2)]
        [InlineData("NZD", 1.30, "AUD", 1)]
        public void ExchangeRateTests(string sourceCurrency, decimal sourceValue, string expectedCurrency, decimal expectedValue)
        {
            var sourceMoney = new Money() { Value = sourceValue, Currency = sourceCurrency };

            var destinationMoney = sourceMoney.ToCurrency(expectedCurrency, new FakeExchangeRatesProvider());

            Assert.Equal(expectedCurrency, destinationMoney.Currency);

            Assert.Equal(expectedValue, destinationMoney.Value);
        }
    }
}
