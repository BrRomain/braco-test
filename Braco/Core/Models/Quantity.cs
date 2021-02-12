using System;

namespace Core.Models
{
    public class Quantity
    {
        public Quantity(double scalar, Unit unit)
        {
            Scalar = scalar;
            Unit = unit;
        }

        public double Scalar { get; }

        public Unit Unit { get; }

        private bool Equals(Quantity other)
        {
            return Scalar.Equals(other.Scalar) && Equals(Unit, other.Unit);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == GetType() && Equals((Quantity) other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Scalar, Unit);
        }

        public override string ToString()
        {
            return $"{nameof(Scalar)}: {Scalar}, {nameof(Unit)}: {Unit}";
        }
    }
}