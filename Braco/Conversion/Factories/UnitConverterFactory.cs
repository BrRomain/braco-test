using System;
using Conversion.Converters;
using Core.Models;

namespace Conversion.Factories
{
    internal class UnitConverterFactory : IUnitConverterFactory
    {
        public IUnitConverter Create(Unit from)
        {
            return from.System switch
            {
                UnitSystem.Metric => new MetricUnitConverter(),
                UnitSystem.Imperial => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}