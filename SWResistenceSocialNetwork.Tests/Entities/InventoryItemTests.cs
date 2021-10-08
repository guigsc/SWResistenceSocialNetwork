using SWResistenceSocialNetwork.Domain.Entities;
using System;
using Xunit;

namespace SWResistenceSocialNetwork.Tests.Entities
{
    public class InventoryItemTests
    {

        [Fact]
        public void InventoryItem_Valid_ShouldCreateInventoryItem()
        {
            // Arrange
            int itemId = 1;
            int quantity = 2;

            // Act
            var inventoryItem = new InventoryItem(itemId, quantity);

            // Assert
            Assert.IsType<InventoryItem>(inventoryItem);
        }

        [InlineData(0)]
        [InlineData(-1)]
        [Theory]
        public void InventoryItem_WithInvalidItemId_ShouldCreateInventoryItem(int itemId)
        {
            // Arrange
            int quantity = 1;
;
            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new InventoryItem(itemId, quantity));
        }

        [InlineData(-1)]
        [Theory]
        public void InventoryItem_WithInvalidQuantity_ShouldCreateInventoryItem(int quantity)
        {
            // Arrange
            int itemId = 1;
            ;
            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new InventoryItem(itemId, quantity));
        }

        [Fact]
        public void InventoryItem_AddQuantity_ShouldIncreaseQuantity()
        {
            // Arrange
            var inventoryItem = new InventoryItem(1, 2);

            // Act
            inventoryItem.AddQuantity(2);

            // Assert
            Assert.Equal(4, inventoryItem.Quantity);
        }

        [Fact]
        public void InventoryItem_HasQuantityWithInputGreaterThanQuantity_ShouldBeFalse()
        {
            // Arrange
            var inventoryItem = new InventoryItem(1, 2);

            // Act
            bool hasQuantity = inventoryItem.HasQuantity(3);

            // Assert
            Assert.False(hasQuantity);
        }

        [InlineData(1)]
        [InlineData(2)]
        [Theory]
        public void InventoryItem_HasQuantityWithInputLessOrEqualThanQuantity_ShouldBeTrue(int quantity)
        {
            // Arrange
            var inventoryItem = new InventoryItem(1, 2);

            // Act
            bool hasQuantity = inventoryItem.HasQuantity(quantity);

            // Assert
            Assert.True(hasQuantity);
        }

        [Fact]
        public void InventoryItem_SubtractQuantity_ShouldDecreaseQuantity()
        {
            // Arrange
            var inventoryItem = new InventoryItem(1, 2);

            // Act
            inventoryItem.SubtractQuantity(1);

            // Assert
            Assert.Equal(1, inventoryItem.Quantity);
        }

        [Fact]
        public void InventoryItem_SubtractGreaterQuantity_ShouldNotSubtract()
        {
            // Arrange
            var inventoryItem = new InventoryItem(1, 2);

            // Act
            inventoryItem.SubtractQuantity(3);

            // Assert
            Assert.Equal(2, inventoryItem.Quantity);
        }

        [Fact]
        public void InventoryItem_CalculatePoints_ShouldMultiplyQuantityByItemPoints()
        {
            // Arrange
            var item = new Item("Item", 2);
            var inventoryItem = new InventoryItem(1, 3);
            inventoryItem.LoadItem(item);

            // Act
            int points = inventoryItem.CalculatePoints();

            // Assert
            Assert.Equal(6, points);
        }

        [Fact]
        public void InventoryItem_LoadItem_ShouldLoadItemObject()
        {
            // Arrange
            var item = new Item("Item", 2);
            var inventoryItem = new InventoryItem(1, 3);

            // Act
            inventoryItem.LoadItem(item);

            // Assert
            Assert.NotNull(inventoryItem.Item);
        }
    }
}
