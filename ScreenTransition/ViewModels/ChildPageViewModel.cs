using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class ChildPageViewModel : BindableBase
    {
        public ReactiveProperty<string> MsgText { get; set; } = new ReactiveProperty<string>();
        public AsyncReactiveCommand CloseCommand { get; set; } = new AsyncReactiveCommand();
        public AsyncReactiveCommand NextPageCommand { get; set; } = new AsyncReactiveCommand();
        private INavigationService _navigationService;

        public ChildPageViewModel(INavigationService navigation)
        {
            _navigationService = navigation;

            MsgText.Value = "ChildPage";

            CloseCommand.Subscribe(_ => OnCloseCommandAsync());
            NextPageCommand.Subscribe(_ => OnNextPageCommandAsync());
        }

        private async Task OnNextPageCommandAsync()
        {
            await _navigationService.NavigateAsync("ChildSecondPage");
        }

        private async Task OnCloseCommandAsync()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
