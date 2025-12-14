using RecipesSupport.Tests.Integration.Base;
using Xunit;

namespace RecipesSupport.Tests.Integration
{
    [Collection("Shared Integration Tests")]
    public class RecipesControllerTests
    {
        private readonly ApplicationFactory _applicationFactory;

        public RecipesControllerTests(ApplicationFactory applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }


        [Fact]
        public async Task GetItems_ReturnsOkResponse()
        {
            // Arrange
            var requestUri = "Recipes/searchByIngredients?ingredients=butter";

            // Act
            var client = _applicationFactory.AsNotAuthenticated();
            var response = await client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Console.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
            }

            // Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseData);
        }
    }
}