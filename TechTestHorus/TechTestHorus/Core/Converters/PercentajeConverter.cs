using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TechTestHorus.Core.Converters
{
    public class PercentajeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (int)value;
            var vald = (double)val;
            if (val == 0) 
            {
                return 0;
            }
            double divi = vald / 100;
            return divi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
