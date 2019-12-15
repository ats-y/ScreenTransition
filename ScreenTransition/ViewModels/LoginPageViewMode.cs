using System;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class LoginPageViewMode : BindableBase
    {
        private readonly INavigationService _navigationService;

        public ReactiveCommand LoginCommand { get; set; } = new ReactiveCommand();

        public LoginPageViewMode(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand.Subscribe(x =>
            {
                Debug.WriteLine("ログイン");
                _navigationService.NavigateAsync("/RootPage/NavigationPage/MainPage");
            });
        }
    }
}
