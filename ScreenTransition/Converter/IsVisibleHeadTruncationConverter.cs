using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScreenTransition.Converter
{
    /// <summary>
    /// ScrollViewの横スクロール量とScrollViewの表示内容から
    /// 先頭省略記号の表示是非に変換するコンバータ。
    /// </summary>
    public class IsVisibleHeadTruncationConverter : IValueConverter
    {
        public IsVisibleHeadTruncationConverter()
        {
        }

        /// <summary>
        /// 先頭省略記号の表示是非に変換する。
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
            if (scroll.ContentSize.Width <= scroll.Width ) return false;

            // 右方向にスクロールしていれば表示する。
            return ((double)value > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
