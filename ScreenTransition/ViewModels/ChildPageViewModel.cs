using System;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class ChildPageViewModel : BindableBase
    {
        public ReactiveProperty<string> MsgText { get; set; } = new ReactiveProperty<string>();

        public ReactiveCommand CloseCommand { get; set; } = new ReactiveCommand();

        private INavigationService _navigationService;

        public ChildPageViewModel(INavigationService navigation)
        {
            _navigationService = navigation;

            MsgText.Value = "Child Page Text";

            CloseCommand.Subscribe(_ => OnCloseCommand());
        }

        private void OnCloseCommand()
        {
            _navigationService.GoBackAsync();
        }
    }
}
