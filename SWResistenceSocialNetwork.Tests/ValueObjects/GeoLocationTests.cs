using SWResistenceSocialNetwork.Domain.ValueObjects;
using System;
using Xunit;

namespace SWResistenceSocialNetwork.Tests.ValueObjects
{
    public class GeoLocationTests
    {
        [Fact]
        public void GeoLocation_Valid_ShouldCreate()
        {
            // Arrange
            var latitude = 10.534351;
            var longitude = 10.12312;
            var name = "Uldur";

            // Act
            var geoLocation = new GeoLocation(latitude, longitude, name);

            // Assert
            Assert.IsType<GeoLocation>(geoLocation);
        }

        [InlineData("")]
        [InlineData(null)]
        [Theory]
        public void GeoLocation_NameNullOrEmpty_ShouldThrowException(string name)
        {
            // Arrange
            var latitude = 10.534351;
            var longitude = 10.12312;

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new GeoLocation(latitude, longitude, name));
        }
    }
}
