using System;

namespace SWResistenceSocialNetwork.Domain.Entities
{
    public class InventoryItem : Entity
    {
        public int RebelId { get; private set; }
        public int ItemId { get; private set; }
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        private InventoryItem() { }

        public InventoryItem(int itemId, int quantity)
        {
            if (itemId <= 0)
                throw new ArgumentException("ItemId should be greater than 0");

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be less than zero");

            ItemId = itemId;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public bool HasQuantity(int quantity)
        {
            return Quantity >= quantity;
        }

        public void SubtractQuantity(int quantity)
        {
            if (!HasQuantity(quantity)) return;
            Quantity -= quantity;
        }

        public int CalculatePoints()
        {
            return Item.Points * Quantity;
        }

        public void LoadItem(Item item)
        {
            Item = item;
        }
    }
}
