using RecipesSupport.Tests.Integration.Base;

namespace RecipesSupport.Tests.Integration.Controllers
{
    public class RecipesControllerTests : IntegrationTestBase
    {
        [Test]
        public async Task GetItems_ReturnsOkResponse()
        {
            // Arrange
            var requestUri = "Recipes/searchByIngredients?ingredients=butter";

            // Act
            var response = await TestClient.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseData);
        }
    }
}