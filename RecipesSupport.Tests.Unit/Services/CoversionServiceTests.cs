using AwesomeAssertions;
using Moq;
using RecipesSupport.Application.Interfaces.Repositories;
using RecipesSupport.Application.Services;

namespace RecipesSupport.Tests.Unit.Services
{
    public class ConversionServiceTests
    {
        private readonly Mock<IUnitOfMeasureRepository> _uomRepMock;

        private ConversionService _sut;

        public ConversionServiceTests()
        {
            _uomRepMock = new Mock<IUnitOfMeasureRepository>();

            _sut = new ConversionService(_uomRepMock.Object);
        }

        [Theory]
        [InlineData(4, 2, 1, 2)]
        [InlineData(6, 3, 2, 4)]
        [InlineData(1.75, 1, 0.5, 0.875)]
        public void ConversionService_Scale_Success(decimal currentQuanity, decimal currentServings, decimal newServings, decimal expected)
        {
            //Arrange
            //Act
            var result = _sut.Scale(currentQuanity, currentServings, newServings);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, 1, 2, 2000)]
        [InlineData(1, 1000, 2, 0.002)]
        [InlineData(1000, 5, 0.25, 50)]
        [InlineData(28.3495, 1, 4, 113.3980)]
        public async Task ConversionService_Convert_Success(decimal conversionFactorCurrentUnit, decimal conversionFactorNewUnit, decimal newQuantity, decimal expected)
        {
            //Arrange
            _uomRepMock.Setup(x => x.GetByUnitNameAsync("currentUnitName"))
                .ReturnsAsync(new RecipesSupport.Application.Models.UnitOfMeasureDTO
                {
                    BaseConversionFactor = conversionFactorCurrentUnit,
                    UnitType = "UnitType",
                    Name = "currentUnitName",
                });
            _uomRepMock.Setup(x => x.GetByUnitNameAsync("newUnitName"))
                .ReturnsAsync(new RecipesSupport.Application.Models.UnitOfMeasureDTO
                {
                    BaseConversionFactor = conversionFactorNewUnit,
                    UnitType = "UnitType",
                    Name = "newUnitName",
                });

            //Act
            var result = await _sut.Convert(newQuantity, "currentUnitName", "newUnitName");

            //Assert
            result.Should().Be(expected);
        }
    }

}
