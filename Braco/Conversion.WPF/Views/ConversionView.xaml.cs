using System.Reactive.Disposables;
using Conversion.ViewModels;
using ReactiveUI;

namespace Conversion.WPF.Views
{
    public partial class ConversionView : ReactiveUserControl<ConversionViewModel>
    {
        public ConversionView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, x => x.UnitTypes, x => x.UnitTypesCombobox.ItemsSource)
                    .DisposeWith(disposable);
                
                this.OneWayBind(ViewModel, x => x.Units, x => x.UnitsToConvert.ItemsSource)
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel, x => x.Units, x => x.ConvertedUnits.ItemsSource)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, x => x.SelectedType, x => x.UnitTypesCombobox.SelectedItem)
                    .DisposeWith(disposable);
                
                this.Bind(ViewModel, x => x.CurrentUnit, x => x.UnitsToConvert.SelectedItem)
                    .DisposeWith(disposable);
                
                this.Bind(ViewModel, x => x.TargetUnit, x => x.ConvertedUnits.SelectedItem)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, x => x.ToConvert, x => x.InputToConvert.Text)
                    .DisposeWith(disposable);
                
                this.Bind(ViewModel, x => x.Converted, x => x.ConvertedOutput.Text)
                    .DisposeWith(disposable);
            }); 
        }
    }
}