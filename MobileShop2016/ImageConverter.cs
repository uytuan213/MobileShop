using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MobileShop2016
{
    class ImageConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string v = value.ToString();
            string link = string.Format(@"C:\Users\Pui Pui\Desktop\LTUDQL 2\images\{0}\{1}.jpg", v, v);
            return link;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
