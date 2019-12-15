using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScreenTransition.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ログインEntryの入力完了イベントハンドラ
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        public void OnUserIdComplited(object s, EventArgs e)
        {
            // パスワードEntryにフォーカスを移動する。
            PasswordEntry.Focus();
        }

        /// <summary>
        /// パスワードEntryにフォーカスがあたったイベントハンドラ
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        public void OnPasswordFocused(object s, EventArgs e)
        {
            // 文字を全選択にする。
            string password = PasswordEntry.Text;
            if (!string.IsNullOrEmpty(password))
            {
                PasswordEntry.CursorPosition = 0;
                PasswordEntry.SelectionLength = password.Length;
            }
        }
    }
}
