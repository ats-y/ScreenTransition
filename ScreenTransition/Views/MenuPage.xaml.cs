using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ScreenTransition.ViewModels;
using Xamarin.Forms;

namespace ScreenTransition.Views
{
    public partial class MenuPage : ContentPage
    {
        private RootPageViewModel ViewModel => this.BindingContext as RootPageViewModel;

        /// <summary>
        /// 現在選択中のメニュー項目。
        /// メニュー変更でキャンセルされた際に、メニュー選択前のメニューに戻すために利用する。
        /// </summary>
        private object currentMenu = null;

        public MenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// メニューListView選択イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("ListViewMenu_ItemSelected");

            // 同じメニューが選択された場合は何もしない。
            // ※通常同じメニューを選択しても本イベントは呼ばれないが、
            //  本イベント内でSelectedItemを元に戻した後に呼ばれてしまうため。
            if (e.SelectedItem == currentMenu)
            {
                Debug.WriteLine("selected same");
                return;
            }

            // 現在表示中のPageを取得する。
            MasterDetailPage mdp = Parent as MasterDetailPage;
            if (mdp != null)
            {
                NavigationPage naviPage = mdp.Detail as NavigationPage;
                if( naviPage != null)
                {
                    // 現在表示中のPageに変更可能かどうか確認する。
                    ITrasitionPage trasition = naviPage.CurrentPage as ITrasitionPage;
                    if (trasition != null)
                    {
                        Task<bool> task = trasition.BeforeTransitionTask();
                        if (task != null)
                        {
                            bool ret = await task;
                            if (!ret)
                            {
                                // 変更不可だったのでメニューを変更前に戻す。
                                mdp.IsPresented = false;
                                ListView myself = (ListView)sender;
                                myself.SelectedItem = currentMenu;
                                return;
                            }
                        }
                    }
                }
            }

            // 現在選択中のメニュー項目を保存し、Detail画面を遷移させる。
            currentMenu = e.SelectedItem;
            await this.ViewModel.PageChangeAsync(e.SelectedItem as ViewModels.MenuItem);
        }
    }
}
