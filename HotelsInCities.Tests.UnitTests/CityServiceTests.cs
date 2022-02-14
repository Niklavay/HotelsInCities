using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Services.Services.Implementation;
using Moq;
using Xunit;

namespace HotelsInCities.Tests.UnitTests
{
    public class CityServiceTests
    {
        [Fact]
        public void CityServiceGetById_NullParameter_ReturnsNull()
        {
            //Arrange
            var mock = new Mock<>();
            var service = new CityService()

            //Act
            var result = mock.
        }

    }
}