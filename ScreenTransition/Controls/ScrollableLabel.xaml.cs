using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ScreenTransition.Controls
{
    /// <summary>
    /// スクロール可能ラベル。
    /// </summary>
    public partial class ScrollableLabel : ContentView
    {
        public ScrollableLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォントサイズを設定するバインダブルプロパティ。
        /// </summary>
        #region FontSize BindableProperty
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(ScrollableLabel), null, BindingMode.TwoWay, propertyChanged: OnFontSizePropertyChanged);

        private static void OnFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ScrollableLabel scrollableLabel)) return;
            scrollableLabel.TextDispLabel.FontSize = (double)newValue;
            scrollableLabel.HeadTruncation.FontSize = (double)newValue;
            scrollableLabel.TailTruncation.FontSize = (double)newValue;
        }

        [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        #endregion

        /// <summary>
        /// 表示文字列を設定するバインダブルプロパティ。
        /// </summary>
        #region Text BindableProperty
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(ScrollableLabel), null, BindingMode.TwoWay, propertyChanged: OnTextPropertyChanged);

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ScrollableLabel scrollableLabel)) return;
            scrollableLabel.TextDispLabel.Text = newValue as string;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        /// <summary>
        /// 省略記号プロパティ変化イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnTruncationPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "IsVisible") return;
            if (!(sender is VisualElement element)) return;
            if (element.IsVisible == false) return;

            // 省略記号表示エリアの背景色を決める。
            // ラベル文字列の上に省略記号をかぶせるので、透明でない背景色の親View探す。
            Color background = Color.Transparent;
            VisualElement search = element;
            while (search != null)
            {
                background = search.BackgroundColor;
                if (background.A > 0) break;
                search = search.Parent as VisualElement;
            }
            element.BackgroundColor = background;
        }

        /// <summary>
        /// ラベルサイズ変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnLabelSizeChanged(object sender, EventArgs args)
        {
            // ラベルの初回表示で末端省略記号を表示するかどうか決める。
            Debug.WriteLine($"OnLabelSizeChanged {TextDispLabel.Width}/{scrV.Width} ");
            TailTruncation.IsVisible = (TextDispLabel.Width - scrV.Width > 0);
        }

        /// <summary>
        /// スクロールイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnScrolled(object sender, ScrolledEventArgs args)
        {
            // パラメータチェック。
            if (!(sender is ScrollView sv)) return;

            // 先頭省略記号表示制御。
            // スクロール位置が左端より右にあれば表示する。
            HeadTruncation.IsVisible = (0 < args.ScrollX);

            // 末端省略記号表示制御。
            // スクロール位置が右端よりも左にあれば表示する。
            bool isVisible = false;
            double scrollSize = sv.ContentSize.Width - sv.Width;
            if (0 < scrollSize && args.ScrollX < scrollSize)
            {
                isVisible = true;
            }
            TailTruncation.IsVisible = isVisible;
        }
    }
}
