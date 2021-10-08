using SWResistenceSocialNetwork.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SWResistenceSocialNetwork.Domain.Entities
{
    public class Rebel : Entity
    {
        public Name Name { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public GeoLocation GeoLocation { get; private set; }
        public Inventory Inventory { get; private set; }
        public int TotalReports { get; private set; }
        public bool IsTraitor { get; private set; }

        private readonly int maxReports = 3;

        private Rebel() { }

        public Rebel(Name name, int age, string gender, GeoLocation geoLocation, List<InventoryItem> items)
        {
            if (age < 18)
                throw new ArgumentException("The rebel should be 18+ years");

            if (string.IsNullOrEmpty(gender))
                throw new ArgumentException("Invalid gender");

            Name = name;
            Age = age;
            Gender = gender;
            GeoLocation = geoLocation;
            Inventory = new Inventory(items);
        }

        public void UpdateGeoLocation(double latitude, double longitude, string name)
        {
            GeoLocation = new(latitude, longitude, name);
        }

        public void TakeItems(List<InventoryItem> items)
        {
            Inventory.TakeItems(items);
        }

        public void AddItems(List<InventoryItem> items)
        {
            Inventory.AddItems(items);
        }

        public void ReportAsTraitor()
        {
            if (IsTraitor) return;

            TotalReports++;
            if (TotalReports >= maxReports)
            {
                IsTraitor = true;
            }
        }

        public bool CanTrade(List<InventoryItem> items)
        {
            return !IsTraitor && Inventory.HasItems(items);
        }
    }
}
