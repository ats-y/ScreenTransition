using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace ScreenTransition.ViewModels
{
    /// <summary>
    /// MasterDetailPageのViewModel
    /// </summary>
    public class RootPageViewModel : BindableBase
    {
        /// <summary>
        /// メニューに一覧表示するメニュー。
        /// </summary>
        public ObservableCollection<MenuItem> Menus { get; } = new ObservableCollection<MenuItem>
        {
            new MenuItem
            {
                Title = "メイン",
                PageName = "MainPage"
            },
            new MenuItem
            {
                Title = "サブページ",
                PageName = "SubPage"
            },
            new MenuItem
            {
                Title = "Accounts",
                PageName = "AccountsPage"
            },
        };

        /// <summary>
        /// PrismのNavigationService
        /// </summary>
        private INavigationService NavigationService { get; }

        /// <summary>
        /// メニュー表示状態。
        /// </summary>
        public ReactiveProperty<bool> IsPresented = new ReactiveProperty<bool>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService"></param>
        public RootPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        /// <summary>
        /// ページを遷移する。
        /// </summary>
        /// <param name="menuItem">メニューで選択されたアイテム</param>
        /// <returns></returns>
        public async Task PageChangeAsync(MenuItem menuItem)
        {
            await this.NavigationService.NavigateAsync($"NavigationPage/{menuItem.PageName}");

            // Master（メニュー）を隠す。
            this.IsPresented.Value = false;
        }
    }
}
