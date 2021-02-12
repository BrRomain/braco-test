using Conversion.Converters;
using Core.Models;
using NFluent;
using Xunit;
using static Core.Models.UnitPrefix;
using static Core.Models.UnitSystem;
using static Core.Models.UnitType;

namespace Conversion.Tests.Converters
{
    public class TestMetricUnitConverter
    {
        private readonly MetricUnitConverter sut;

        public TestMetricUnitConverter()
        {
            sut = new MetricUnitConverter();
        }

        [Theory]
        [ClassData(typeof(ConverterTestData))]
        public void GivenValidInputsItShouldReturnAValidQuantity(Quantity toConvert, Unit expectedUnit,
            Quantity expected)
        {
            Check.That(sut.Convert(toConvert, expectedUnit))
                .IsEqualTo(expected);
        }

        private class ConverterTestData : TheoryData<Quantity, Unit, Quantity>
        {
            private readonly Unit centi = BuildUnit(Centi);
            private readonly Unit milli = BuildUnit(Milli);
            private readonly Unit kilo = BuildUnit(Kilo);
            private readonly Unit metre = BuildUnit(Metre);
            private readonly Unit hecto = BuildUnit(Hecto);
            private readonly Unit deca = BuildUnit(Deca);

            public ConverterTestData()
            {
                Add(new Quantity(5, metre), centi, new Quantity(500, centi));
                Add(new Quantity(-2, metre), centi, new Quantity(-200, centi));
                Add(new Quantity(30, centi), metre, new Quantity(0.3, metre));
                Add(new Quantity(1000, milli), kilo, new Quantity(0.001, kilo));
                Add(new Quantity(50, hecto), deca, new Quantity(500, deca));
                Add(new Quantity(1000, deca), hecto, new Quantity(100, hecto));
            }

            private static Unit BuildUnit(UnitPrefix prefix) => new Unit(prefix, Length, Metric);
        }
    }
}