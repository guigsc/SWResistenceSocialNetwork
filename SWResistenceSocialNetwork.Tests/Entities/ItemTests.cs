using SWResistenceSocialNetwork.Domain.Entities;
using System;
using Xunit;

namespace SWResistenceSocialNetwork.Tests.Entities
{
    public class ItemTests
    {
        [Fact]
        public void Item_Valid_ShouldNotThrowExceptions()
        {
            // Arrange
            var name = "Item";
            var points = 1;


            // Act
            var item = new Item(name, points);

            // Assert
            Assert.IsType<Item>(item);
        }

        [InlineData("")]
        [InlineData(null)]
        [Theory]
        public void Item_NameNullOrEmpty_ShouldThrowException(string name)
        {
            // Arrange
            var points = 1;

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new Item(name, points));
        }
    }
}
