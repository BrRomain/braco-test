using Conversion.Factories;
using Core.Models;
using static Core.Models.UnitSystem;

namespace Conversion.ViewModels
{
    public class UnitViewModel
    {
        public UnitViewModel(UnitPrefix prefix, UnitType type)
        {
            Name = new LabelFactory(type).LabelFor(prefix);
            Unit = new Unit(prefix, type, Metric);
        }

        public string Name { get; }
        
        public Unit Unit { get; }
    }
}