using System;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class ChildPageViewModel : BindableBase, INavigationAware, IDestructible
    {
        public ReactiveProperty<string> MsgText { get; set; } = new ReactiveProperty<string>();

        public ChildPageViewModel()
        {
            MsgText.Value = "Child Page Text";
        }

        public void Destroy()
        {
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
