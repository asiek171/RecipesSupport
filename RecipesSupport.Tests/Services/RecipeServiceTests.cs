using Application.Services;
using Application.Services.Strategy.Factory;
using Application.Services.Strategy.Interfaces;
using MediatR;
using Moq;

namespace RecipesSupport.Tests.Services
{
    public class RecipeServiceTests
    {
        private readonly Mock<IMediator> _mediatr;
        private readonly Mock<IntegrationStrategyFactory> _factory;

        private RecipeService _service;

        public RecipeServiceTests()
        {
            _mediatr = new Mock<IMediator>();
            _factory = new Mock<IntegrationStrategyFactory>();

            _service = new RecipeService(_factory.Object, _mediatr.Object);
        }

        [Fact]
        public void Test_test()
        {
            //Arrange
            //Act
            var result = 1 + 1;
            //var result = await _service.GetByRecipeId(1);
            //Assert
            Assert.Equal(2, result);
        }
    }

}
