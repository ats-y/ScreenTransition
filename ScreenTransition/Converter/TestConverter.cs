using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScreenTransition.Converter
{
    public class TestConverter : IValueConverter
    {
        public TestConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double scrollX = (double)value;
            return (scrollX > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
