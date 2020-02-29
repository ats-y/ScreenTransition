using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    public class MultiLineTitleSamplePageViewModel : INavigatedAware, IInitialize
    {
        public ReactiveProperty<string> TitleText1 { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> TitleText2 { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> TitleText3 { get; } = new ReactiveProperty<string>();

        private const string PARAM = "param";

        public MultiLineTitleSamplePageViewModel()
        {
        }

        public static async void NavigateAsync(INavigationService navi,
            string title1, string title2, string title3)
        {
            NavigationParameters naviParams = new NavigationParameters();
            naviParams.Add(PARAM, new RequestParameters
            {
                Title1 = title1,
                Title2 = title2,
                Title3 = title3,
            });
            await navi.NavigateAsync("MultiLineTitleSamplePage", naviParams);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine("MultiLineTitleSamplePageViewModel.OnNavigatedTo()");
        }

        public void Initialize(INavigationParameters parameters)
        {
            Debug.WriteLine("MultiLineTitleSamplePageViewModel.Initialize()");

            RequestParameters req = parameters.GetValue<RequestParameters>(PARAM);
            TitleText1.Value = req.Title1;
            TitleText2.Value = req.Title2;
            TitleText3.Value = req.Title3;
        }

        public class RequestParameters
        {
            public string Title1 { get; set; }
            public string Title2 { get; set; }
            public string Title3 { get; set; }
        }
    }
}
