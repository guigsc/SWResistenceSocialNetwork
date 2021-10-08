using SWResistenceSocialNetwork.Domain.ValueObjects;
using System;
using Xunit;

namespace SWResistenceSocialNetwork.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void Name_Valid_ShouldCreate()
        {
            // Arrange
            var firstName = "First name";
            var lastName = "Last name";

            // Act
            var name = new Name(firstName, lastName);

            // Assert
            Assert.IsType<Name>(name);
        }

        [InlineData("")]
        [InlineData(null)]
        [Theory]
        public void GeoLocation_FirstNameNullOrEmpty_ShouldThrowException(string firstName)
        {
            // Arrange
            var lastName = "Last name";

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new Name(firstName, lastName));
        }

        [InlineData("")]
        [InlineData(null)]
        [Theory]
        public void GeoLocation_LastNameNullOrEmpty_ShouldThrowException(string lastName)
        {
            // Arrange
            var firstName = "First name";

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new Name(firstName, lastName));
        }
    }
}
