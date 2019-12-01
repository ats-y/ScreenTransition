using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using ScreenTransition.ViewModels;
using ScreenTransition.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScreenTransition
{
    public partial class App : PrismApplication
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
            //NavigationService.NavigateAsync("/NavigationPage/ChildPage");
            NavigationService.NavigateAsync("/RootPage/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RootPage, RootPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SubPage, SubPageViewModel>();
            containerRegistry.RegisterForNavigation<ChildPage, ChildPageViewModel>();
            containerRegistry.RegisterForNavigation<ChildSecondPage, ChildSecondPageViewModel>();

        }
    }
}
