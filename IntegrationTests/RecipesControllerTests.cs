using RecipesSupport.Tests.Integration.Base;
using Xunit;

namespace IntegrationTests
{
    public class RecipesControllerTests : IntegrationTestBase
    {
        [Fact]
        public async Task GetItems_ReturnsOkResponse()
        {
            // Arrange
            var requestUri = "/Recipes/searchByIngredients?ingredients=butter";

            // Act
            var response = await TestClient.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseData);
        }
    }
}