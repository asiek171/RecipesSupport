using Application.Services;
using Application.Services.Strategy.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace RecipesSupport.Tests.Unit.Services
{
    public class RecipeServiceTests
    {
        private readonly Mock<IIntegrationFactory> _factory;
        private readonly Mock<ILogger<RecipeService>> _logger;

        private RecipeService _service;

        public RecipeServiceTests()
        {
            _factory = new Mock<IIntegrationFactory>();
            _logger = new Mock<ILogger<RecipeService>>();

            _service = new RecipeService(_factory.Object,_logger.Object);
        }

        [Fact]
        public  void Test_test()
        {
            //Arrange
            //Act
            var result = 1 + 1;
            //    _factory.Setup(_ => _.GetStrategy(It.IsAny<SystemType>())).Returns(new EdamamStrategy(It.IsAny<EdamamService>()));
            //    var result = await _service.GetByIngredients("butter");
            //Assert
            Assert.Equal(2, result);
        }
    }

}
