using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public AsyncReactiveCommand<string> NavigateCommand { get; set; } = new AsyncReactiveCommand<string>();
        public AsyncReactiveCommand<string> ModalNavigateCommand { get; set; } = new AsyncReactiveCommand<string>();

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand.Subscribe(OnNavigate);
            ModalNavigateCommand.Subscribe(OnModalNavigate);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatedFrom");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatedTo");
        }

        private async Task OnNavigate(string parameter)
        {
            Debug.WriteLine($"OnNavigate {parameter}");
            await _navigationService.NavigateAsync(parameter, useModalNavigation: false);
        }

        private async Task OnModalNavigate(string parameter)
        {
            Debug.WriteLine($"OnModalNavigate {parameter}");
            await _navigationService.NavigateAsync(parameter, useModalNavigation: true);
        }


    }
}
