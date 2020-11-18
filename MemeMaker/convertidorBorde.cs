using System;
using System.Globalization;
using System.Windows.Data;

namespace MemeMaker
{
    class ConvertidorBorde : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value is true) return 3;
            else return 0;

        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
