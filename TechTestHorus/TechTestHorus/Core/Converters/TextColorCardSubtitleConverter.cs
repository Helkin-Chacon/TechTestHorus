using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TechTestHorus.Core.Converters
{
    public class TextColorCardSubtitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var obj = (bool)value;
            if (!obj)
            {
                return (Color)App.Current.Resources["CDarkGray"];
            }
            else
            {
                return Color.White;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
