using System;

namespace Core.Models
{
    public class Unit
    {
        public Unit(UnitPrefix prefix, UnitType type, UnitSystem system)
        {
            Prefix = prefix;
            Type = type;
            System = system;
        }

        public UnitType Type { get; }

        public UnitSystem System { get; }

        public UnitPrefix Prefix { get; }

        private bool Equals(Unit other)
        {
            return Type == other.Type && System == other.System && Prefix == other.Prefix;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == GetType() && Equals((Unit) other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Type, (int) System, (int) Prefix);
        }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(System)}: {System}, {nameof(Prefix)}: {Prefix}";
        }
    }
}