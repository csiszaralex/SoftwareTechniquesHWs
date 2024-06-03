using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoXaml.Models;

namespace TodoXaml.Converters
{
    public class PriorityBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            value = (Priority)value;
            switch (value)
            {
                case Priority.Low:
                    return new SolidColorBrush(Colors.LightSkyBlue);
                case Priority.Normal:
                    return (Brush)App.Current.Resources["ApplicationForegroundThemeBrush"];
                case Priority.High:
                    return new SolidColorBrush(Colors.IndianRed);
                default:
                    return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
