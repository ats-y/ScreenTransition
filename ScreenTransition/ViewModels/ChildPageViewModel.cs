using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class ChildPageViewModel : BindableBase
    {
        public ReactiveProperty<string> TitleText1 { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> TitleText2 { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> TitleText3 { get; } = new ReactiveProperty<string>();

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

            TitleText1.Value = "たいとる1";
            TitleText2.Value = "たいとる2";
            TitleText3.Value = "たいとる3";
        }

        private async Task OnNextPageCommandAsync()
        {
            await _navigationService.NavigateAsync("ChildSecondPage");
        }

        private async Task OnCloseCommandAsync()
        {
            await _navigationService.GoBackAsync(useModalNavigation: true);
        }
    }
}
