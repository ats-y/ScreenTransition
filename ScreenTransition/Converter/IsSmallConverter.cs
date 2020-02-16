using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScreenTransition.Converter
{
    public class IsSmallConverter : IValueConverter
    {
        public IsSmallConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ScrollView
            VisualElement ve = parameter as VisualElement;
            if (ve == null) return false;

            return ((double)value > ve.Width);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
