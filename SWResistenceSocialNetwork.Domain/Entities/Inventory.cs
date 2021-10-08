using System.Collections.Generic;
using System.Linq;

namespace SWResistenceSocialNetwork.Domain.Entities
{
    public class Inventory
    {
        public List<InventoryItem> Items { get; private set; }

        public Inventory()
        {
            Items = new List<InventoryItem>();
        }

        public Inventory(List<InventoryItem> items)
        {
            if (items == null)
                Items = new List<InventoryItem>();
            else
                Items = items;
        }

        public bool HasItem(InventoryItem item)
        {
            if (item == null) return false;

            return Items.Any(inventoryItem => inventoryItem.ItemId == item.ItemId && inventoryItem.HasQuantity(item.Quantity));
        }

        public bool HasItems(List<InventoryItem> items)
        {
            if (items == null) return false;

            return items.All(item => HasItem(item));
        }

        public int CalculatePoints()
        {
            return Items.Sum(item => item.CalculatePoints());
        }

        public void AddItem(InventoryItem item)
        {
            if (item == null) return;

            var inventoryItem = GetItem(item.ItemId);
            if (inventoryItem == null)
            {
                Items.Add(item);
            }
            else
            {
                inventoryItem.AddQuantity(item.Quantity);
            }
        }

        public void AddItems(List<InventoryItem> items)
        {
            if (items == null) return;

            items.ForEach(item => AddItem(item));
        }

        public void TakeItem(InventoryItem item)
        {
            if (item == null) return;

            var inventoryItem = GetItem(item.ItemId);
            if (inventoryItem == null) return;

            if (!inventoryItem.HasQuantity(item.Quantity)) return;

            inventoryItem.SubtractQuantity(item.Quantity);

            if (inventoryItem.Quantity == 0)
                Items.Remove(inventoryItem);
        }

        public void TakeItems(List<InventoryItem> items)
        {
            if (items == null) return;

            items.ForEach(item => TakeItem(item));
        }

        public bool IsTradePossible(Inventory otherInventory)
        {
            if (otherInventory == null) return false;

            return CalculatePoints() == otherInventory.CalculatePoints();
        }

        private InventoryItem GetItem(int itemId)
        {
            return Items.FirstOrDefault(i => i.ItemId == itemId);
        }

    }
}
