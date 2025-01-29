using System;

namespace CarteiraDigital.Domain.ValueObjects
{
    public class ExampleValueObject
    {
        public string Value { get; private set; }

        public ExampleValueObject(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is ExampleValueObject other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}