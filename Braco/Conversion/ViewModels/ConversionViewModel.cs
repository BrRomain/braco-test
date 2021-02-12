using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive.Linq;
using Conversion.Factories;
using Core.Constants;
using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Conversion.ViewModels
{
    public class ConversionViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly ObservableAsPropertyHelper<IList<UnitViewModel>> units;

        public ConversionViewModel(IScreen screen)
        {
            HostScreen = screen;

            UnitTypes = Enum.GetValues<UnitType>()
                .Select(type => new UnitTypeViewModel(type))
                .ToImmutableList();

            SelectedType = UnitTypes.Last();

            units = this.WhenAnyValue(x => x.SelectedType)
                .Where(typeViewModel => typeViewModel != null)
                .Select(typeViewModel => Enum.GetValues<UnitPrefix>()
                    .Select(prefix => new UnitViewModel(prefix, typeViewModel.Type))
                    .ToImmutableList())
                .ToProperty(this, x => x.Units, ImmutableList<UnitViewModel>.Empty);

            var whenAnyUnits = this.WhenAnyValue(x => x.Units)
                .Where(unitViewModels => unitViewModels.Any())
                .Select(unitViewModels => unitViewModels.First());

            whenAnyUnits
                .BindTo(this, x => x.CurrentUnit);

            whenAnyUnits
                .BindTo(this, x => x.TargetUnit);

            var whenAnyCurrentUnit = this.WhenAnyValue(x => x.CurrentUnit)
                .Where(currentUnit => currentUnit != null);

            var whenAnyTargetUnit = this.WhenAnyValue(x => x.TargetUnit)
                .Where(targetUnit => targetUnit != null);
            
            this.WhenAnyValue(x => x.ToConvert)
                .Where(toConvert => !string.IsNullOrWhiteSpace(toConvert))
                .Select(Convert.ToDouble)
                .CombineLatest(whenAnyCurrentUnit, whenAnyTargetUnit)
                .Select(x =>
                    new UnitConverterFactory()
                        .Create(x.Second.Unit)
                        .Convert(new Quantity(x.First, x.Second.Unit), x.Third.Unit))
                .Select(quantity => quantity.Scalar)
                .BindTo(this, x => x.Converted);
        }

        public string UrlPathSegment => NavigationModules.ConversionModule;

        public IScreen HostScreen { get; }

        public IList<UnitTypeViewModel> UnitTypes { get; }

        public IList<UnitViewModel> Units => units.Value;

        [Reactive] 
        public UnitTypeViewModel SelectedType { get; set; }

        [Reactive] 
        public UnitViewModel CurrentUnit { get; set; }

        [Reactive] 
        public UnitViewModel TargetUnit { get; set; }

        [Reactive] 
        public string ToConvert { get; set; }

        [Reactive] 
        public string Converted { get; set; }
    }
}