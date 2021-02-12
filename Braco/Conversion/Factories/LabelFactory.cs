using System;
using Core.Models;

namespace Conversion.Factories
{
    public class LabelFactory
    {
        private readonly string suffix;

        public LabelFactory(UnitType type)
        {
            suffix = BuildSuffixFor(type);
        }

        public string LabelFor(UnitPrefix prefix)
        {
            return $"{prefix}{suffix}";
        }

        private string BuildSuffixFor(UnitType type)
        {
            return type switch
            {
                UnitType.Length => "metre",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}