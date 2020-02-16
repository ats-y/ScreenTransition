using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScreenTransition.Converter
{
    /// <summary>
    /// ScrollViewの横スクロール量とScrollViewの表示内容から
    /// 末尾省略記号の表示是非に変換するコンバータ。
    /// </summary>
    public class IsVisibleTailTruncationConverter : IValueConverter
    {
        public IsVisibleTailTruncationConverter()
        {
        }

        /// <summary>
        /// 末尾省略記号の表示是非に変換する。
        /// </summary>
        /// <param name="value">ScrollView.ScrollXを指定する</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">ScrollViewを指定する。</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // パラメータチェック。
            if (!(parameter is ScrollView scroll)) return false;

            // ScrollViewがスクロール不可であれば非表示。
            double scrollSize = scroll.ContentSize.Width - scroll.Width;
            if (scrollSize <= 0) return false;

            // 右方向にスクロールしきっていなければ表示する。
            return ((double)value < scrollSize );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
