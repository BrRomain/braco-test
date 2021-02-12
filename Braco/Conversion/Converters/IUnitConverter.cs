using System.Runtime.CompilerServices;
using Core.Models;

[assembly: InternalsVisibleTo("Conversion.Tests")]

namespace Conversion.Converters
{
    public interface IUnitConverter
    {
        Quantity Convert(Quantity from, Unit to);
    }
}