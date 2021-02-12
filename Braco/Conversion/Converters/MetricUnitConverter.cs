using System;
using System.Collections.Generic;
using Core.Models;
using static Core.Models.UnitPrefix;

namespace Conversion.Converters
{
    public class MetricUnitConverter : IUnitConverter
    {
        private readonly IDictionary<UnitPrefix, int> multiplierByPrefix;

        public MetricUnitConverter()
        {
            multiplierByPrefix = new Dictionary<UnitPrefix, int>
            {
                {Milli, -3},
                {Centi, -2},
                {Deci, -1},
                {Metre, 0},
                {Deca, 1},
                {Hecto, 2},
                {Kilo, 3}
            };
        }

        public Quantity Convert(Quantity from, Unit to)
        {
            if (!multiplierByPrefix.ContainsKey(from.Unit.Prefix)) throw new NotSupportedException();

            var powerOfFrom = multiplierByPrefix[from.Unit.Prefix];
            var powerOfTo = multiplierByPrefix[to.Prefix];

            return new Quantity(from.Scalar * Math.Pow(10, powerOfFrom - powerOfTo), to);
        }
    }
}