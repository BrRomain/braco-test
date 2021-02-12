using Conversion.Converters;
using Core.Models;

namespace Conversion.Factories
{
    public interface IUnitConverterFactory
    {
        IUnitConverter Create(Unit from);
    }
}