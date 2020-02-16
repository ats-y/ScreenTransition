using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScreenTransition.Converter
{
    public class IsLargerConverter : IValueConverter
    {
        public IsLargerConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ScrollView target = parameter as ScrollView;
            if (target == null) return false;

            return ((double)value < (target.ContentSize.Width - target.Width));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
