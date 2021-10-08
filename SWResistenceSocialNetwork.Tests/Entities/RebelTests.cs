using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace SWResistenceSocialNetwork.Tests.Entities
{
    public class RebelTests
    {
        [Fact]
        public void Rebel_Valid_ShouldNotThrowExceptions()
        {
            // Arrange
            Name name = new Name("Bryanik", "Aubetit");
            GeoLocation geoLocation = new GeoLocation(10.02314561, 23.15234551, "Ono");
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 4),
                new InventoryItem(2, 3),
                new InventoryItem(3, 1),
                new InventoryItem(4, 2)
            };
            string gender = "Male";
            int age = 18;

            // Act
            var rebel = new Rebel(name, age, gender, geoLocation, items);

            // Assert
            Assert.IsType<Rebel>(rebel);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Rebel_GenderNullOrEmpty_ShouldThrowException(string gender)
        {
            // Arrange
            Name name = new Name("Bryanik", "Aubetit");
            GeoLocation geoLocation = new GeoLocation(10.02314561, 23.15234551, "Ono");
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 4),
                new InventoryItem(2, 3),
                new InventoryItem(3, 1),
                new InventoryItem(4, 2)
            };
            int age = 18;

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new Rebel(name, age, gender, geoLocation, items));
        }

        [Fact]
        public void Rebel_UnderAge_ShouldThrowException()
        {
            // Arrange
            Name name = new Name("Bryanik", "Aubetit");
            GeoLocation geoLocation = new GeoLocation(10.02314561, 23.15234551, "Ono");
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 4),
                new InventoryItem(2, 3),
                new InventoryItem(3, 1),
                new InventoryItem(4, 2)
            };
            string gender = "Male";
            int age = 17;


            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => new Rebel(name, age, gender, geoLocation, items));
        }

        [Fact]
        public void Rebel_ReportAsTraitor_ShouldIncreaseTotalReportByOne()
        {
            // Arrange
            Name name = new Name("Bryanik", "Aubetit");
            GeoLocation geoLocation = new GeoLocation(10.02314561, 23.15234551, "Ono");
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 4),
                new InventoryItem(2, 3),
                new InventoryItem(3, 1),
                new InventoryItem(4, 2)
            };
            string gender = "Male";
            int age = 18;
            var rebel = new Rebel(name, age, gender, geoLocation, items);

            // Act
            rebel.ReportAsTraitor();

            // Assert
            Assert.Equal(1, rebel.TotalReports);
        }

        [Fact]
        public void Rebel_ReportAsTraitorThreeTimes_ShouldSetRebelAsTraitor()
        {
            // Arrange
            Name name = new Name("Bryanik", "Aubetit");
            GeoLocation geoLocation = new GeoLocation(10.02314561, 23.15234551, "Ono");
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 4),
                new InventoryItem(2, 3),
                new InventoryItem(3, 1),
                new InventoryItem(4, 2)
            };
            string gender = "Male";
            int age = 18;
            var rebel = new Rebel(name, age, gender, geoLocation, items);

            // Act
            rebel.ReportAsTraitor();
            rebel.ReportAsTraitor();
            rebel.ReportAsTraitor();

            // Assert
            Assert.True(rebel.IsTraitor);
        }

        [Fact]
        public void Rebel_UpdateGeoLocation_ShouldBeUpdated()
        {
            // Arrange
            Name name = new Name("Bryanik", "Aubetit");
            GeoLocation geoLocation = new GeoLocation(10.02314561, 23.15234551, "Ono");
            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(1, 4),
                new InventoryItem(2, 3),
                new InventoryItem(3, 1),
                new InventoryItem(4, 2)
            };
            string gender = "Male";
            int age = 18;

            var rebel = new Rebel(name, age, gender, geoLocation, items);

            // Act
            rebel.UpdateGeoLocation(23.15234551, 10.02314561, "Uldur");

            // Assert
            var expected = new GeoLocation(23.15234551, 10.02314561, "Uldur");
            Assert.Equal(rebel.GeoLocation, expected);
        }
    }
}
