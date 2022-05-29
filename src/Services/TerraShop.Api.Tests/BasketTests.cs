using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TerraShop.Api.ShoppingCart.Query;
using Xunit;

namespace TerraShop.Api.Tests
{
    public class BasketTests
    {
        [Fact]
        public async Task GivenAVisitorAddAProductToBasketABasketIsCreated()
        {
            using WebApplicationFactory<Program>? factory = new WebApplicationFactory<Program>();

            var client = factory.CreateClient();

            var visitorId = Guid.NewGuid();

            var payLoad = new
            {
                VisitorId = visitorId,
                ProductId = new Guid("f3dba809-4906-4692-a8d5-2995269ce441"), // This is bit of cheating it's one of the hard coded productIds,
                Quantity = 1
            };

            var response = await client.PostAsync($"/Basket/{visitorId}", new StringContent(JsonSerializer.Serialize(payLoad), Encoding.UTF8, "application/json"));

            _ = response.EnsureSuccessStatusCode();

            var checkBasket = await client.GetAsync(($"/Basket/{visitorId}"));

            checkBasket.EnsureSuccessStatusCode();

            string? body = await checkBasket.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<GetBasket.Response>(body, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            }); 

            Assert.NotNull(result);
            Assert.True(result!.Items.Count == 1);

        }
    }
}
