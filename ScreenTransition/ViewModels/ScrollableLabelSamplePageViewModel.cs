using System;
using Prism.Navigation;
using Reactive.Bindings;
using Xamarin.Forms;

namespace ScreenTransition.ViewModels
{
    public class ScrollableLabelSamplePageViewModel
    {
        public ReactiveProperty<string> Title1 { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Title2 { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Title3 { get; } = new ReactiveProperty<string>();
        public Command MultiLineTitlePageCommand { get; }
        private INavigationService _naviService;

        public ScrollableLabelSamplePageViewModel(INavigationService naviService)
        {
            _naviService = naviService;
            MultiLineTitlePageCommand = new Command(OnMultiLineTitlePageCommand);
        }

        private void OnMultiLineTitlePageCommand(object parameter)
        {
            MultiLineTitleSamplePageViewModel.NavigateAsync(_naviService,
                Title1.Value, Title2.Value, Title3.Value);
        }
    }
}
