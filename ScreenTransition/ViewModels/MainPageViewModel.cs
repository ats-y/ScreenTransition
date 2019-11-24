using System;
using System.Diagnostics;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Xamarin.Forms;

namespace ScreenTransition.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public INavigationService _navigationService;

        public AsyncReactiveCommand NextPageCommand { get; set; } = new AsyncReactiveCommand();

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NextPageCommand.Subscribe(_ => OnNextPageCommandAsync());
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatedFrom");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatedTo");
        }

        private async System.Threading.Tasks.Task OnNextPageCommandAsync()
        {
            Debug.WriteLine("OnNextPageCommandAsync");
            await _navigationService.NavigateAsync("NavigationPage/ChildPage", useModalNavigation:true);
        }
    }
}
