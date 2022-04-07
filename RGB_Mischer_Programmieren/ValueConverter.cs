using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RGB_Mischer_Programmieren
{
    [ValueConversion(typeof(double), typeof(string))]
    public class ValueConverter : IValueConverter
    {
        #region Definition Converter
        public object Convert(object value, Type targetType,
                                object parameter, CultureInfo culture)
        {
            string param = parameter as string;
            int test = System.Convert.ToInt32(value);
            if (param != null)
                return test.ToString(param);
            throw new InvalidCastException();
        }
        #endregion

        #region Definition ConverterBack
        public object ConvertBack(object value, Type targetType,
                                object parameter, CultureInfo culture)
        {
            //Siehe Projekt Hezahl_in_Gleitkommazahl 
            string rgbValue = value as string;
            int rgbValueChanged = 0;
            int.TryParse(rgbValue, NumberStyles.HexNumber, null, out rgbValueChanged);
            double newValue = System.Convert.ToDouble(rgbValueChanged);
            return newValue;
        }
        #endregion
    }
}
