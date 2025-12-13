using Moq;
using ReciesSupport.Application.Interfaces;
using ReciesSupport.Application.Services;

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

        [Fact]
        public void ConversionService_Scale_Success()
        {
            //Arrange
            //Act
            var result = _sut.Scale(4, 2, 1);
            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public async Task ConversionService_Convert_Success()
        {
            //Arrange
            //Act
            _uomRepMock.Setup(x => x.GetByUnitNameAsync("kilogram"))
                .ReturnsAsync(new ReciesSupport.Application.Models.UnitOfMeasureDTO
                {
                    BaseConversionFactor = 1000m,
                    UnitType = "Weight",
                    Name = "kilogram",
                });
            _uomRepMock.Setup(x => x.GetByUnitNameAsync("gram"))
                .ReturnsAsync(new ReciesSupport.Application.Models.UnitOfMeasureDTO
                {
                    BaseConversionFactor = 1m,
                    UnitType = "Weight",
                    Name = "gram",
                });

            var result = await _sut.Convert(2, "kilogram", "gram");

            //Assert
            Assert.Equal(2000m, result);
        }
    }

}
