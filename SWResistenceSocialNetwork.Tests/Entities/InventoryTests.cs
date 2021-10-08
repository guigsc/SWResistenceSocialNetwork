using SWResistenceSocialNetwork.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace SWResistenceSocialNetwork.Tests.Entities
{
    public class InventoryTests
    {

        [Fact]
        public void Inventory_Valid_ShouldCreateListOfInventoryItem()
        {
            // Arrange
            
            // Act
            var inventory = new Inventory();

            // Assert
            Assert.IsType<Inventory>(inventory);
        }

        [Fact]
        public void Inventory_WithValidItems_ShouldCreateListOfInventoryItem()
        {
            // Arrange
            List<InventoryItem> inventoryItems = new List<InventoryItem>();
;
            // Act
            var inventory = new Inventory(inventoryItems);

            // Assert
            Assert.NotNull(inventory.Items);
        }

        [Fact]
        public void Inventory_WithNullItems_ShouldCreateListOfInventoryItem()
        {
            // Arrange
            
            // Act
            var inventory = new Inventory(null);

            // Assert
            Assert.NotNull(inventory.Items);
        }

        [Fact]
        public void Inventory_HasExistingItem_ShouldBeTrue()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 3)
            };
            var inventory = new Inventory(items);

            // Act
            bool hasItem = inventory.HasItem(new InventoryItem(1, 1));

            // Assert
            Assert.True(hasItem);
        }

        [Fact]
        public void Inventory_DoesntHaveItemWithSameId_ShouldBeFalse()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 3)
            };
            var inventory = new Inventory(items);

            // Act
            bool hasItem = inventory.HasItem(new InventoryItem(2, 1));

            // Assert
            Assert.False(hasItem);
        }

        [Fact]
        public void Inventory_DoesntHaveItemWithValidQuantity_ShouldBeFalse()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 2)
            };
            var inventory = new Inventory(items);

            // Act
            bool hasItem = inventory.HasItem(new InventoryItem(1, 5));

            // Assert
            Assert.False(hasItem);
        }

        [Fact]
        public void Inventory_HasExistingItems_ShouldBeTrue()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 2),
                new InventoryItem(2, 3)
            };
            var inventory = new Inventory(items);

            // Act
            bool hasItems = inventory.HasItems(new List<InventoryItem>
            {
                new InventoryItem(1, 1),
                new InventoryItem(2, 1)
            });

            // Assert
            Assert.True(hasItems);
        }

        [Fact]
        public void Inventory_HasItemsWithNullList_ShouldBeFalse()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 2),
                new InventoryItem(2, 3)
            };
            var inventory = new Inventory(items);

            // Act

            bool hasItems = inventory.HasItems(null);

            // Assert
            Assert.False(hasItems);
        }

        [Fact]
        public void Inventory_CalculatePoints_ShouldReturnSumOfAllPoints()
        {
            // Arrange
            var item1 = new InventoryItem(1, 2);
            item1.LoadItem(new Item("Item1", 4));

            var item2 = new InventoryItem(2, 4);
            item2.LoadItem(new Item("Item2", 3));

            List<InventoryItem> items = new List<InventoryItem> { item1, item2 };
            var inventory = new Inventory(items);
            
            // Act
            int points = inventory.CalculatePoints();

            // Assert
            Assert.Equal(20, points);
        }

        [Fact]
        public void Inventory_AddItem_ShouldAddItem()
        {
            // Arrange
            var inventory = new Inventory();
            var inventoryItem = new InventoryItem(1, 2);

            // Act
            inventory.AddItem(inventoryItem);

            // Assert
            Assert.Single(inventory.Items);
        }

        [Fact]
        public void Inventory_AddNullItem_ShouldNotAdd()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            inventory.AddItem(null);

            // Assert
            Assert.Empty(inventory.Items);
        }

        [Fact]
        public void Inventory_AddExistingItem_ShouldIncreaseQuantity()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.AddItem(new InventoryItem(1, 4));

            // Assert
            int addedItemQuantity = inventory.Items[0].Quantity;
            Assert.Equal(6, addedItemQuantity);
        }

        [Fact]
        public void Inventory_AddMultipleItems_ShouldAddItems()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            inventory.AddItems(new List<InventoryItem>
            {
                new InventoryItem(1, 2),
                new InventoryItem(2, 1),
            });

            // Assert
            Assert.Equal(2, inventory.Items.Count);
        }

        [Fact]
        public void Inventory_AddNullListOfItems_ShouldNotAddItems()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            inventory.AddItems(null);

            // Assert
            Assert.Empty(inventory.Items);
        }

        [Fact]
        public void Inventory_TakeItem_ShouldReduceQuantity()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItem(new InventoryItem(1, 1));

            // Assert
            Assert.Equal(1, inventory.Items[0].Quantity);
        }

        [Fact]
        public void Inventory_TakeNullItem_ShoulNotTakeItem()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItem(null);

            // Assert
            Assert.Equal(2, inventory.Items[0].Quantity);
        }

        [Fact]
        public void Inventory_TakeNonExistingItem_ShoulNotTakeItem()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItem(new InventoryItem(2, 1));

            // Assert
            Assert.Equal(2, inventory.Items[0].Quantity);
        }

        [Fact]
        public void Inventory_TakeItemWithNoAvailableQuantity_ShoulNotTakeItem()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItem(new InventoryItem(1, 3));

            // Assert
            Assert.Equal(2, inventory.Items[0].Quantity);
        }

        [Fact]
        public void Inventory_TakeItemWithExactQuantity_ShouldRemoveItem()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItem(new InventoryItem(1, 2));

            // Assert
            Assert.Empty(inventory.Items);
        }

        [Fact]
        public void Inventory_TakeItems_ShouldTakeItems()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2), new InventoryItem(2, 1) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItems(new List<InventoryItem> { new InventoryItem(1, 2), new InventoryItem(2, 1) });

            // Assert
            Assert.Empty(inventory.Items);
        }

        [Fact]
        public void Inventory_TakeNullListOfItems_ShouldNotTakeItems()
        {
            // Arrange
            List<InventoryItem> items = new List<InventoryItem> { new InventoryItem(1, 2) };
            var inventory = new Inventory(items);

            // Act
            inventory.TakeItems(null);

            // Assert
            Assert.Single(inventory.Items);
        }

        [Fact]
        public void Inventory_IsTradePossible_ShouldBeTrue()
        {
            // Arrange
            var item1 = new InventoryItem(1, 2);
            item1.LoadItem(new Item("Item1", 4));
            var buyerInventory = new Inventory();
            buyerInventory.AddItem(item1);

            var item2 = new InventoryItem(2, 4);
            item2.LoadItem(new Item("Item2", 2));
            var sellerInventory = new Inventory();
            sellerInventory.AddItem(item2);

            // Act
            bool isTradePossible = buyerInventory.IsTradePossible(sellerInventory);

            // Assert
            Assert.True(isTradePossible);
        }

        [Fact]
        public void Inventory_IsTradePossibleWithDifferentAmountOfPoints_ShouldBeFalse()
        {
            // Arrange
            var item1 = new InventoryItem(1, 2);
            item1.LoadItem(new Item("Item1", 4));
            var buyerInventory = new Inventory();
            buyerInventory.AddItem(item1);

            var item2 = new InventoryItem(2, 4);
            item2.LoadItem(new Item("Item2", 3));
            var sellerInventory = new Inventory();
            sellerInventory.AddItem(item2);

            // Act
            bool isTradePossible = buyerInventory.IsTradePossible(sellerInventory);

            // Assert
            Assert.False(isTradePossible);
        }
    }
}
