using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using TechTestHorus.Core.Resources.CustomMarckupExtension;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace TechTestHorus.Core.Converters
{
    public class ImageCardChallengeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var obj = (bool)value;
            if (!obj)
            {
                return ImageSource.FromResource("TechTestHorus.Core.Resources.arrow_right_g.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            }
            else
            {
                return ImageSource.FromResource("TechTestHorus.Core.Resources.arrow_right_w.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);


            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
