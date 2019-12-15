using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScreenTransition.Views
{
    public partial class Modal01Page : ContentPage
    {
        public Modal01Page()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // ios:Page.ModalPresentationStyle="FormSheet"にすると上スワイプで閉じたあと
            // 再度ダイアログを表示できない（ポップできていない？）
            // これを防ぐために、自分でポップする。
            // https://xamarinhowto.com/controlling-ios-13-modal-presentation-styles-in-xamarin-forms/
            Navigation.PopModalAsync();
        }
    }
}
