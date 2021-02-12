using Core.Models;

namespace Conversion.ViewModels
{
    public class UnitTypeViewModel
    {
        public UnitTypeViewModel(UnitType unitType)
        {
            Type = unitType;
        }

        public string Name => Type.ToString();
        
        public UnitType Type { get; }
    }
}