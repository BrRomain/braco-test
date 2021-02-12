using System.Reactive.Disposables;
using ReactiveUI;
using Shell.WPF.ViewModels;

namespace Shell.WPF
{
    public partial class ShellView : ReactiveWindow<ShellViewModel>
    {
        public ShellView()
        {
            InitializeComponent();
            
            ViewModel = new ShellViewModel();
            
            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposable);
            });
        }
    }
}