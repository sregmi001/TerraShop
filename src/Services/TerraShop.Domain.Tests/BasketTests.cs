using System;
using System.Linq;
using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.Shared;
using TerraShop.Domain.ShoppingCart;
using Xunit;

namespace TerraShop.Domain.Tests
{
    public class BasketTests
    {

        [Fact]
        public void GivenABasketWhenAddNewProductBasketItemsAreUpdated()
        {
            //Given
            var basket = Basket.Create(VisitorId.NewId());
            var productId = ProductId.NewId();
            var unitPrice = new Money { Currency = "AUD", Value = 3 };

            // When
            basket.AddItem(productId, unitPrice, 1);

            //Then
            var basketItem = basket.Items.First();

            Assert.NotNull(basketItem);
            Assert.Equal(productId, basketItem.ProductId);
            Assert.Equal(1, basketItem.Quantity);
        }

        [Fact]
        public void GivenABasketWhenAddingItemWithNegativeQuantityThenExceptionIsThrown()
        {
            //Given
            var basket = Basket.Create(VisitorId.NewId());
            var productId = ProductId.NewId();
            var unitPrice = new Money { Currency = "AUD", Value = 3 };

            // When
            var testCode = () => basket.AddItem(productId, unitPrice, -1);

            Assert.Throws<ArgumentOutOfRangeException>(testCode);
        }

        [Fact]
        public void GivenABasketWithExistingItemWhenAddingSameItemBasketItemQuanityIsUpdate()
        {
            //Given
            var basket = Basket.Create(VisitorId.NewId());
            var productId = ProductId.NewId();
            var unitPrice = new Money { Currency = "AUD", Value = 3 };
            basket.AddItem(productId, unitPrice, 1);

            // When
            basket.AddItem(productId, unitPrice, 1);

            //Then

            Assert.Equal(1, basket.Items.Count);

            var basketItem = basket.Items.First();

            Assert.NotNull(basketItem);
            Assert.Equal(productId, basketItem.ProductId);
            Assert.Equal(2, basketItem.Quantity);
        }

        [Fact]
        public void GivenABasketWhenRemovingNonExistingItemThenBasketRemainsUnchanged()
        {
            var basket = Basket.Create(VisitorId.NewId());
            var productIdA = ProductId.NewId();
            var productIdB = ProductId.NewId();
            var unitPrice = new Money { Currency = "AUD", Value = 3 };
            basket.AddItem(productIdA, unitPrice, 1);

            // When
            basket.DeleteItem(productIdB);

            //Then

            Assert.Equal(1, basket.Items.Count);

            var basketItem = basket.Items.FirstOrDefault(i => i.ProductId.Value == productIdA.Value);

            Assert.NotNull(basketItem);
        }

        [Fact]
        public void GivenABasketWithExistingItemWhenRemovingItemTheItemIsNolongerInTheBasket()
        {
            //Given
            var basket = Basket.Create(VisitorId.NewId());
            var productIdA = ProductId.NewId();
            var productIdB = ProductId.NewId();
            var unitPrice = new Money { Currency = "AUD", Value = 3 };
            basket.AddItem(productIdA, unitPrice, 1);
            basket.AddItem(productIdB, unitPrice, 1);

            // When
            basket.DeleteItem(productIdA);

            //Then

            Assert.Equal(1, basket.Items.Count);

            var basketItem = basket.Items.FirstOrDefault(i => i.ProductId.Value == productIdA.Value);

            Assert.Null(basketItem);
        }

        [Fact]
        public void GivenABasketWithItemsThenTotalExShippingShouldCalculateCorrectly()
        {
            //Given
            var basket = Basket.Create(VisitorId.NewId());
            var productIdA = ProductId.NewId();
            var productIdB = ProductId.NewId();
            var unitPrice = new Money { Currency = "AUD", Value = 3 };
            basket.AddItem(productIdA, unitPrice, 1);
            basket.AddItem(productIdB, unitPrice, 1);

            var exchangeRateProvider = new FakeExchangeRatesProvider();


            Assert.Equal(new Money
            {
                Value = 6
            }, basket.TotalExShipping(exchangeRateProvider));
        }
    }
}