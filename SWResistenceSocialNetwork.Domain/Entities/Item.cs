using System;

namespace SWResistenceSocialNetwork.Domain.Entities
{
    public class Item : Entity
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        private Item() { }

        public Item(string name, int points)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name should not be null or empty");

            Name = name;
            Points = points;
        }
    }
}
