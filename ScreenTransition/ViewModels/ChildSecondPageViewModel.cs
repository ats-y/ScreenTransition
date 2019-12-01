using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class ChildSecondPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        public AsyncReactiveCommand CloseCommand { get; set; } = new AsyncReactiveCommand();

        public ChildSecondPageViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            CloseCommand.Subscribe(_ => OnCloseCommandAsync());
        }

        private async Task OnCloseCommandAsync()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
