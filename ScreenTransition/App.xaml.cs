using System;
using Prism;
using Prism.Ioc;
using ScreenTransition.ViewModels;
using ScreenTransition.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScreenTransition
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {

        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // 起動直後にMainPageを表示する。
            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            // View「MainPage」ViewModels「MainPageViewModel」を登録する。
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }

}
