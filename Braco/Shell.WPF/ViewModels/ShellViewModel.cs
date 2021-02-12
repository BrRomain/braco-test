using System;
using Conversion.ViewModels;
using Conversion.WPF.Views;
using ReactiveUI;
using Splat;

namespace Shell.WPF.ViewModels
{
    public class ShellViewModel : ReactiveObject, IScreen
    {
        public ShellViewModel()
        {
            Router = new RoutingState();
            
            Locator.CurrentMutable.Register(() => new ConversionView(), typeof(IViewFor<ConversionViewModel>));

            ReactiveCommand
                .CreateFromObservable(() => Router.Navigate.Execute(new ConversionViewModel(this)))
                .Execute()
                .Subscribe();
        }

        public RoutingState Router { get; }
    }
}