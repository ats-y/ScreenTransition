using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScreenTransition.Views
{
    public partial class SubPage : ContentPage, ICanChanging
    {
        public SubPage()
        {
            InitializeComponent();
        }

        public Task<bool> CanChanging()
        {
            return DisplayAlert("確認", "ページを切り替えて良いですか？", "ええで", "あかん");
        }
    }
}
