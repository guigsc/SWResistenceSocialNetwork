using System;
using System.Collections.Generic;

namespace SWResistenceSocialNetwork.Domain.ValueObjects
{
    public class GeoLocation : ValueObject
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string Name { get; private set; }
        
        public GeoLocation(double latitude, double longitude, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"Name cannot be null nor empty");

            Latitude = latitude;
            Longitude = longitude;
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
            yield return Name;
        }
    }
}
