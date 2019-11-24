using System;
namespace ScreenTransition.ViewModels
{
    /// <summary>
    /// メニューの一要素
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailに表示する画面名
        /// </summary>
        public string PageName { get; set; }
    }
}
