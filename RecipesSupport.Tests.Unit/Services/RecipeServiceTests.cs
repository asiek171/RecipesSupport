using Application.Services;
using Application.Services.Strategy.Interfaces;
using MediatR;
using Moq;

namespace RecipesSupport.Tests.Unit.Services
{
    public class RecipeServiceTests
    {
        private readonly Mock<IMediator> _mediatr;
        private readonly Mock<IIntegrationFactory> _factory;

        private RecipeService _service;

        public RecipeServiceTests()
        {
            _mediatr = new Mock<IMediator>();
            _factory = new Mock<IIntegrationFactory>();

            _service = new RecipeService(_factory.Object, _mediatr.Object);
        }

        [Fact]
        public async Task Test_test()
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
