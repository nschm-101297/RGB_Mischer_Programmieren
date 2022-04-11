using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RGB_Mischer_Programmieren
{
    public class ColorValueConverter : IValueConverter
    {
        #region Converter
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            //string param = parameter as string;
            //System.Windows.Media.Brush newValue = (System.Windows.Media.Brush)value;
            //if (param != null)
            //    return newValue;
            //throw new InvalidCastException();
            var newColor = (System.Drawing.Color)value;
            return new SolidColorBrush(new Color { A = newColor.A, B = newColor.B, R = newColor.R, G = newColor.G });

        }
        #endregion

        #region ConverterBack
        public object ConvertBack(object value, Type targetType,
                             object parameter, CultureInfo culture)
        {
            System.Drawing.Color finsihedcolor = (System.Drawing.Color)value;
            return finsihedcolor;

        }
        #endregion
    }
}
