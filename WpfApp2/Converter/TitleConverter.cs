using System;
using System.Globalization;
using System.Windows.Data;


namespace WpfApp2.Converter
{
    class TitleConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "CefSharp.MinimalExample.Wpf - " + (value ?? "No Title Specified");
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
