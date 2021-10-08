using System;
using System.Collections.Generic;

namespace SWResistenceSocialNetwork.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name (string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException($"First Name cannot be null nor empty");

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException($"Last Name cannot be null nor empty");

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
