using Microsoft.AspNetCore.Mvc.Testing;
using Snapshooter.Xunit;
using System.Threading.Tasks;
using Xunit;

namespace TerraShop.Api.Tests
{
    public class CatalogTests
    {
        [Fact]
        public async Task ProductsAreReturnedCorrectly()
        {
            using WebApplicationFactory<Program>? factory = new WebApplicationFactory<Program>();

            var client = factory.CreateClient();

            var response = await client.GetAsync("/Catalog/Products");

            _ = response.EnsureSuccessStatusCode();

            string? body = await response.Content.ReadAsStringAsync();

            Snapshot.Match(body);

        }
    }
}